using System;
using System.Collections.Generic;

namespace CQRS_EVT
{
    class Program
    {
        static void Main(string[] args)
        {
            EventBroket broker = new EventBroket();
            Car volvo = new Car(broker);

            broker.ExecuteCommand(new SwitchLights(volvo, true));
            broker.ExecuteCommand(new SwitchLights(volvo, false));
            broker.ExecuteCommand(new SwitchLights(volvo, true));

            foreach (var item in broker.AllEvents)
            {
                Console.WriteLine(item);
            }

            var result = broker.ExecuteQuery<string>(new GetLightsStatus());
            Console.WriteLine($"Current status {result}");
        }
    }

    public class Car 
    {
        EventBroket broker = new EventBroket();
        
        private bool isLigthsOn = false; 

        public Car(EventBroket broker)
        {
            this.broker = broker;
            this.broker.Command += SwitchLights;
            this.broker.Query += GetLightsStatus;
        }

        private void GetLightsStatus(object sender, EventArgs e)
        {
            var query = e as GetLightsStatus;
            if (query != null) {
                query.Result = isLigthsOn ? "On" : "Off";
            }
        }

        private void SwitchLights(object sender, EventArgs e)
        {
            var command = e as SwitchLights;

            if (command != null && command.Target == this) 
            {
                this.broker.AllEvents.Add(new EventLightsHistory { target = command.Target, OldValue = isLigthsOn, NewValue = command.isLightsOn });
                isLigthsOn = command.isLightsOn;
            }
        }
    }
    public class EventBroket {
        public IList<Event> AllEvents = new List<Event>();

        public event EventHandler Command;
        public event EventHandler Query;

        public void ExecuteCommand(Command command) {
            Command?.Invoke(this, command);
        }

        public T ExecuteQuery<T>(Query query) {
            Query?.Invoke(this, query);
            return (T)query.Result;
        }
    }

    public class SwitchLights : Command { 
          public bool isLightsOn { get; set; }

        public SwitchLights(Car target, bool isLightsOn)
        {
            this.isLightsOn = isLightsOn;
            base.Target = target;
        }
    }
    public class GetLightsStatus : Query {
    }
    

    public class Command : EventArgs {
        public Car Target { get; set; }
    }
    public class Query : EventArgs { 
        public object Result { get; set; }
    }


    public class Event { }
    public class EventLightsHistory: Event
    {
        public Car target { get; set; }
        public bool OldValue { get; set; }
        public bool NewValue { get; set; }

        public override string ToString()
        {
            return $"Lights switched from {OldValue} to {NewValue}";
        }
    }
}

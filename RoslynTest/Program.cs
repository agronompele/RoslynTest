using Microsoft.CodeAnalysis.CSharp.Scripting;
using RoslynTest.Commands;
using RoslynTest.DomainEvents;
using System;
using System.Threading.Tasks;

namespace RoslynTest
{
    class Program
    {
        static async Task Main()
        {
            const string code = "Command[\"OrderId\"] = DomainEvent[\"OrderId\"];" +
                                "Command[\"DeliveryAddress\"] = DomainEvent[\"DeliveryAddress\"];" +
                                "Command[\"CustomerName\"] = \"John Doe\";";

            DomainEvent domainEvent = new OrderAccepted(Guid.NewGuid(),
                "Neverland");

            Command command = (Command)Activator.CreateInstance(typeof(SendGoodsToCustomer), nonPublic: true);

            var globals = new Globals
            {
                DomainEvent = domainEvent,
                Command = command
            };

            await CSharpScript.EvaluateAsync(code, globals: globals);
        }
    }

    public class Globals
    {
        public DomainEvent DomainEvent;
        public Command Command;
    }
}

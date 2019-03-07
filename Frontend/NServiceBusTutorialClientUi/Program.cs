using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialClientUi
{
    class Program
    {
        static ILog log = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            string title = "NServiceBusTutorialClientUi";
            Console.Title = title;
            var endpointConf = new EndpointConfiguration(title);
            var transport = endpointConf.UseTransport<LearningTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(KeyCommand), "NServiceBusTutorialKeyService");
            routing.RouteToEndpoint(typeof(ComplexKeyCommand), "NServiceBusTutorialKeyService");

            var endpoint = await Endpoint.Start(endpointConf).ConfigureAwait(false);

            await RunLoop(endpoint).ConfigureAwait(false);

            await endpoint.Stop().ConfigureAwait(false);
        }

        private static async Task RunLoop(IEndpointInstance endpoint)
        {
            while (true)
            {
                log.Info("Press Enter to quit");
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key == ConsoleKey.Enter)
                {
                    return;
                }
                else
                {
                    if ((key.Modifiers & ConsoleModifiers.Alt) != 0 || (key.Modifiers & ConsoleModifiers.Shift) != 0 || (key.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        var cmd = new ComplexKeyCommand()
                        {
                            MessageId = Guid.NewGuid().ToString(),
                            KeyCode = key.Key.ToString(),
                            Modifiers = new List<KeyModifier>()
                        };

                        if ((key.Modifiers & ConsoleModifiers.Alt) != 0 )
                        {
                            cmd.Modifiers.Add(new KeyModifier(ConsoleModifiers.Alt.ToString()));
                        }
                        if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                        {
                            cmd.Modifiers.Add(new KeyModifier(ConsoleModifiers.Control.ToString()));
                        }
                        if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            cmd.Modifiers.Add(new KeyModifier(ConsoleModifiers.Shift.ToString()));
                        }

                        await endpoint.SendLocal(cmd).ConfigureAwait(false);
                    }
                    else
                    {
                        var cmd = new KeyCommand
                        {
                            MessageId = Guid.NewGuid().ToString(),
                            KeyCode = key.Key.ToString()
                        };

                        await endpoint.SendLocal(cmd).ConfigureAwait(false);
                    }
                }
            }
        }
    }
}

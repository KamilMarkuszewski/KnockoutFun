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

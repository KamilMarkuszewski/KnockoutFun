using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialShooterService
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            string title = "NServiceBusTutorialShooterService";

            Console.Title = title;

            var conf = new EndpointConfiguration(title);
            var recoverSettings = conf.Recoverability();

            recoverSettings.Immediate(i => i.NumberOfRetries(1));
            conf.SendFailedMessagesTo("error");
            conf.EnableInstallers();

            var transport = conf.UseTransport<LearningTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(ShootCommand), "NServiceBusTutorialKeyService");

            var endpoint = await Endpoint.Start(conf).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpoint.Stop().ConfigureAwait(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NServiceBusTutorialKeyService
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        private static async Task AsyncMain()
        {
            string title = "NServiceBusTutorialKeyService";

            Console.Title = title;

            var conf = new EndpointConfiguration(title);

            var transport = conf.UseTransport<LearningTransport>();

            var endpoint = await Endpoint.Start(conf).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpoint.Stop().ConfigureAwait(false);
        }
    }
}

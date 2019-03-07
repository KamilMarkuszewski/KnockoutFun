using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBusTutorialERPService;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialKeyService
{
    class KeyCommandHandler : IHandleMessages<ReloadCommand>, IHandleMessages<KeyPressedEvent>, IHandleMessages<ComplexKeyPressedEvent>
    {
        static ILog log = LogManager.GetLogger<KeyCommandHandler>();

        private static string dummyGuid = Guid.NewGuid().ToString();

        public Task Handle(ReloadCommand message, IMessageHandlerContext context)
        {
            log.Info("RELOADING Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            return Task.CompletedTask;
        }

        public Task Handle(KeyPressedEvent message, IMessageHandlerContext context)
        {
            ProcessKey(message.KeyCode,  context);
            return Task.CompletedTask;
        }

        public Task Handle(ComplexKeyPressedEvent message, IMessageHandlerContext context)
        {
            ProcessKey(message.KeyCode,  context);
            return Task.CompletedTask;
        }

        private void ProcessKey(string keyCode, IMessageHandlerContext context)
        {
            if (keyCode.In("O", "I", "P", "B"))
            {
                IEvent order;
                switch (keyCode)
                {
                    case "O":
                        dummyGuid = Guid.NewGuid().ToString();
                        order = new OrderPlacedEvent
                        {
                            OrderId = dummyGuid
                        };
                        break;
                    case "I":
                        order = new InvoicePlacedEvent()
                        {
                            OrderId = dummyGuid
                        };
                        break;
                    case "P":
                        order = new PaymentPlacedEvent()
                        {
                            OrderId = dummyGuid
                        };
                        break;
                    case "B":
                        order = new DecreePlacedEvent()
                        {
                            OrderId = dummyGuid
                        };
                        break;

                    default:
                        return;
                }

                context.Publish(order).ConfigureAwait(false);
            }
        }
    }
}

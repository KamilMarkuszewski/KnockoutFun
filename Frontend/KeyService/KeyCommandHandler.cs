using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialKeyService
{
    class KeyCommandHandler : IHandleMessages<KeyPressedEvent>, IHandleMessages<ComplexKeyPressedEvent>, IHandleMessages<ReloadCommand>
    {
        static ILog log = LogManager.GetLogger<KeyCommandHandler>();

        public Task Handle(KeyPressedEvent message, IMessageHandlerContext context)
        {
            if (new Random().Next(0, 5) == 0)
            {
                // Simulating problem
                throw new Exception();
            }

            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            return Task.CompletedTask;
        }

        public Task Handle(ComplexKeyPressedEvent message, IMessageHandlerContext context)
        {
            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId + " Key modifiers " + string.Join(", ", message.Modifiers.Select(m => m.KeyCode)));
            return Task.CompletedTask;
        }

        public Task Handle(ReloadCommand message, IMessageHandlerContext context)
        {
            log.Info("RELOADING Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            return Task.CompletedTask;
        }
    }
}

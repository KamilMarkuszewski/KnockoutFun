using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialShooterService
{
    class KeyCommandHandler : IHandleMessages<KeyPressedEvent>, IHandleMessages<ComplexKeyPressedEvent>
    {
        static ILog log = LogManager.GetLogger<KeyCommandHandler>();

        public Task Handle(ComplexKeyPressedEvent message, IMessageHandlerContext context)
        {
            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId + " Key modifiers " + string.Join(", ", message.Modifiers.Select(m => m.KeyCode)));

            if (message.KeyCode == "Enter")
            {
                var shootCmd = new ShootCommand()
                {
                    KeyCode = message.KeyCode,
                    MessageId = message.MessageId
                };

                log.Info("Shooting");
                context.Send(shootCmd).ConfigureAwait(false);
            }


            return Task.CompletedTask;
        }

        public Task Handle(KeyPressedEvent message, IMessageHandlerContext context)
        {
            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);

            if (message.KeyCode == "Enter")
            {
                var shootCmd = new ShootCommand()
                {
                    KeyCode = message.KeyCode,
                    MessageId = message.MessageId
                };

                log.Info("Shooting");
                context.Send(shootCmd).ConfigureAwait(false);
            }

            return Task.CompletedTask;
        }
    }
}

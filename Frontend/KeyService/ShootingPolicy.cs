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
    public class ShootingPolicy : Saga<ShootingPolicyData>, IAmStartedByMessages<KeyPressedEvent>, IAmStartedByMessages<ComplexKeyPressedEvent>, IAmStartedByMessages<ShootCommand>
    {
        static ILog log = LogManager.GetLogger<KeyCommandHandler>();

        public Task Handle(ShootCommand message, IMessageHandlerContext context)
        {
            log.Info("SHOOTING Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            Data.IsShootReceived = true;
            ProcessShoot(context);
            return Task.CompletedTask;
        }

        public Task Handle(KeyPressedEvent message, IMessageHandlerContext context)
        {
            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            if (message.KeyCode == "Enter")
            {
                Data.IsShootKeyReceived = true;
            }

            ProcessShoot(context);
            return Task.CompletedTask;
        }

        public Task Handle(ComplexKeyPressedEvent message, IMessageHandlerContext context)
        {
            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId + " Key modifiers " + string.Join(", ", message.Modifiers.Select(m => m.KeyCode)));
            if (message.KeyCode == "Enter")
            {
                Data.IsShootKeyReceived = true;
            }

            ProcessShoot(context);
            return Task.CompletedTask;
        }

        private void ProcessShoot(IMessageHandlerContext context)
        {
            if (Data.IsShootKeyReceived && Data.IsShootReceived)
            {
                log.Info("User successfully shoot !!!!!!!!");
                MarkAsComplete();
            }
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ShootingPolicyData> mapper)
        {
            mapper.ConfigureMapping<ShootCommand>(m => m.MessageId).ToSaga(sd => sd.MessageId);

            mapper.ConfigureMapping<KeyPressedEvent>(m => m.MessageId).ToSaga(sd => sd.MessageId);

            mapper.ConfigureMapping<ComplexKeyPressedEvent>(m => m.MessageId).ToSaga(sd => sd.MessageId);
        }



    }
}

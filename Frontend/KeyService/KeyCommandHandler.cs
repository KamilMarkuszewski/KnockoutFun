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
    class KeyCommandHandler : IHandleMessages<ReloadCommand>
    {
        static ILog log = LogManager.GetLogger<KeyCommandHandler>();

        public Task Handle(ReloadCommand message, IMessageHandlerContext context)
        {
            log.Info("RELOADING Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            return Task.CompletedTask;
        }
    }
}

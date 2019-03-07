﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialClientUi
{
    class KeyCommandHandler : IHandleMessages<KeyCommand>, IHandleMessages<ComplexKeyCommand>
    {
        static ILog log = LogManager.GetLogger<KeyCommandHandler>();

        public Task Handle(KeyCommand message, IMessageHandlerContext context)
        {
            context.Send(message).ConfigureAwait(false);
            log.Info("Received " + message.GetType().Name + " Key " + message.KeyCode + " Message id " + message.MessageId);
            return Task.CompletedTask;
        }

        public Task Handle(ComplexKeyCommand message, IMessageHandlerContext context)
        {
            context.Send(message).ConfigureAwait(false);
            Console.WriteLine("Received " + message.GetType().Name);
            return Task.CompletedTask;
        }
    }
}

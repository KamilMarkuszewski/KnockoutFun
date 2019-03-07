using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class KeyCommand : ICommand
    {
        public string KeyCode { get; set; }

        public string MessageId { get; set; }
    }
}

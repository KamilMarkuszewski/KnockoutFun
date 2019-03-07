using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class ComplexKeyPressedEvent : IEvent
    {
        public string MessageId { get; set; }

        public string KeyCode { get; set; }

        public List<KeyModifier> Modifiers { get; set; }
    }

    public class KeyModifier
    {
        public string KeyCode;

        public KeyModifier(string keyCode)
        {
            KeyCode = keyCode;
        }
    }
}

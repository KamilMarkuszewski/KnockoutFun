using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class ComplexKeyCommand : ICommand
    {
        public int Id { get; set; }

        public string KeyCode { get; set; }

        public List<KeyModifier> Modifiers { get; set; }
    }

    public class KeyModifier
    {
        public string KeyCode;
    }
}

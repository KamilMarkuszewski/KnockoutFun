using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class PaymentPlacedEvent : IEvent
    {
        public string OrderId { get; set; }
    }
}
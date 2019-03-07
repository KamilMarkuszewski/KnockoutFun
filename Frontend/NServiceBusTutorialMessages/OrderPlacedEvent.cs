using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class OrderPlacedEvent : IEvent
    {
        public string OrderId { get; set; }
    }
}

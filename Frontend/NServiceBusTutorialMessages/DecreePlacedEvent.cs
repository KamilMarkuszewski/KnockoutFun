﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class DecreePlacedEvent : IEvent
    {
        public string OrderId { get; set; }
    }
}
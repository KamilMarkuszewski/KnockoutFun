﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NServiceBusTutorialMessages
{
    public class ShootCommand : ICommand
    {
        public string KeyCode { get; set; }

        public string MessageId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NServiceBusTutorialKeyService
{
    public class ShootingPolicyData : ContainSagaData
    {
        public bool IsShootReceived { get; set; }
        public bool IsShootKeyReceived { get; set; }

        public string MessageId { get; set; }
    }
}

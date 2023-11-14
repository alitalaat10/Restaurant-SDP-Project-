using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Classes.NotificationSystem
{
    public class TwilioSettings
    {
        public string SID { get; } = "MGd843d7b78d177e251f281474f16f83f6";
        public string AccountSID { get; } = "ACa1e6b887f9ec81651cee3ee32f8ae971";
        public string AuthToken { get; } = "f41723915f88b7b3ffd83695cabbe370";
        public string Sender { get;  } = "+13854628521";
    }
}
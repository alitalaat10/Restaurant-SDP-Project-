using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Classes.NotificationSystem
{
    public class MailSettings
    {
        public string Mail { get; } = "adham20191700087@cis.asu.edu.eg";
        public string DisplayName { get; } = "DP-Restaurant";
        public string Password { get; } = "0123100145fF";
        public string Host { get; } = "smtp-mail.outlook.com";
        public int Port { get; } = 587;
    }
}
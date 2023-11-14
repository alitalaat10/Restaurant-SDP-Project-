using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace design_pattern.Classes.NotificationSystem
{
    public class TwilioService
    {
        private readonly TwilioSettings twilio;
        public TwilioService(TwilioSettings TwilioSettings)
        {
            twilio = TwilioSettings;
        }
        public async Task SendNotif(NotifRequest smsRequest)
        {
            TwilioClient.Init(twilio.AccountSID, twilio.AuthToken);
            var message = MessageResource.Create(
                body: smsRequest.Subject + "\n" + smsRequest.Body,
                from: new Twilio.Types.PhoneNumber(twilio.Sender),
                to: new Twilio.Types.PhoneNumber(smsRequest.To)
            );
        }
    }
}
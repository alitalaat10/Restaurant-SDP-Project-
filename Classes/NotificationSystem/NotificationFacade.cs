using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace design_pattern.Classes.NotificationSystem
{
    public class NotificationFacade
    {
        private MailService mailService;
        private MailSettings mailer;
        private TwilioService twilioService;
        private TwilioSettings twilio;

        public NotificationFacade()
        {
            mailer = new MailSettings();
            twilio = new TwilioSettings();
            mailService = new MailService(mailer);
            twilioService = new TwilioService(twilio);
        }
        public async Task SendReservationReminder(string type, string receiver, string Body)
        {
            NotifRequest request = new NotifRequest() { To = receiver, Subject = "Reservation Reminder", Body = Body };
            switch (type)
            {
                case "mail":
                    await mailService.SendNotif(request);
                    break;
                case "sms":
                    await twilioService.SendNotif(request);
                    break;
            }
        }
        public async Task SendCancelReservationNotif(string type, string receiver)
        {
            NotifRequest request = new NotifRequest() { To = receiver, Subject = "Reservation Cancelled", Body = "We are sorry to inform you that your reservation got cancelled" };
            switch (type)
            {
                case "mail":
                    await mailService.SendNotif(request);
                    break;
                case "sms":
                    await twilioService.SendNotif(request);
                    break;
            }
        }
    }
}
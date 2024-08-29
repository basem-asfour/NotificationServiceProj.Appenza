using NotificationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Model.NotificationModels
{
    public class PushNotificationRequest : ISendable
    {
        public string DeviceToken { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}

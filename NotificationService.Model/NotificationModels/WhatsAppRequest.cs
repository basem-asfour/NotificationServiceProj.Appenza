using NotificationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Model.NotificationModels
{
    public class WhatsAppRequest : ISendable
    {
        public string MobileNumber { get; set; }
        public string Message { get; set; }
    }
}

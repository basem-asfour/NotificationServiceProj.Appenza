using NotificationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Model.NotificationModels
{
    public class EmailRequest : ISendable
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}

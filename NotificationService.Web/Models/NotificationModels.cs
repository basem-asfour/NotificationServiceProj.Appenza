namespace NotificationService.Web.Models
{
    public class SmsRequest
    {
        public string MobileNumber { get; set; }
        public string Identity { get; set; }
        public string Message { get; set; }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class WhatsAppRequest
    {
        public string MobileNumber { get; set; }
        public string Message { get; set; }
    }

    public class PushNotificationRequest
    {
        public string DeviceToken { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }

}

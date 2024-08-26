using NotificationService.Web.Models;

namespace NotificationService.Web.Interfaces
{
    public interface INotificationService
    {
        Task SendSmsAsync(SmsRequest request);
        Task SendEmailAsync(EmailRequest request);
        Task SendWhatsAppAsync(WhatsAppRequest request);
        Task SendPushNotificationAsync(PushNotificationRequest request);
    }


}

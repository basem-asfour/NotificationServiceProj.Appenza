using NotificationService.Web.Interfaces;
using NotificationService.Web.Models;

namespace NotificationService.Web.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRabbitMQService _rabbitMQService;

        public NotificationService(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public async Task SendSmsAsync(SmsRequest request)
        {
            _rabbitMQService.PublishMessage("sms_queue", request);
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            _rabbitMQService.PublishMessage("email_queue", request);
        }

        public async Task SendWhatsAppAsync(WhatsAppRequest request)
        {
            _rabbitMQService.PublishMessage("whatsapp_queue", request);
        }

        public async Task SendPushNotificationAsync(PushNotificationRequest request)
        {
            _rabbitMQService.PublishMessage("push_queue", request);
        }
    }
}

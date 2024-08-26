using Newtonsoft.Json;
using NotificationService.Web.Interfaces;
using NotificationService.Web.Models;

namespace NotificationService.Web.Services
{
    public class SmsConsumer : BackgroundService
    {
        private readonly IRabbitMQService _rabbitMQService;

        public SmsConsumer(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _rabbitMQService.ConsumeQueue("sms_queue", ProcessSmsMessage);
            return Task.CompletedTask;
        }

        private void ProcessSmsMessage(string message)
        {
            // Deserialize the message and send the SMS
            var smsRequest = JsonConvert.DeserializeObject<SmsRequest>(message);
            // Logic to send SMS
            Console.WriteLine($"Sending SMS to {smsRequest.MobileNumber}: {smsRequest.Message}");
        }
    }

    // Similarly, create consumers for Email, WhatsApp, and Push Notifications
}

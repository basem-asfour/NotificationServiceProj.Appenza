using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NotificationService.Interface;
using NotificationService.Model.NotificationModels;

namespace NotificationService.BLL.Consumer
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

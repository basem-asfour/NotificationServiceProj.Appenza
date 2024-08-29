using NotificationService.Interface;
namespace NotificationService.BLL.Provider
{
    public class NotificationProvider : INotificationProvider
    {
        private readonly IRabbitMQService _rabbitMQService;

        public NotificationProvider(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        public async Task SendAsync(ISendable request)
        {
            _rabbitMQService.PublishMessage("push_queue", request);
        }
    }
}

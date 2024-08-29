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

        public List<ISendable> GetAll()
        {
            throw new NotImplementedException();
        }

        public ISendable GetSingle(long id)
        {
            throw new NotImplementedException();
        }

        public async Task SendAsync(ISendable request)
        {
            _rabbitMQService.PublishMessage("push_queue", request);
        }

        public Task Update(ISendable request)
        {
            throw new NotImplementedException();
        }
    }
}

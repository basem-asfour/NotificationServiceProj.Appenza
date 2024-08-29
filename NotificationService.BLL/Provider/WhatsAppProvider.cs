using NotificationService.Interface;
using NotificationService.Model.NotificationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.BLL.Provider
{
    public class WhatsAppProvider : INotificationProvider
    {
        private readonly IRabbitMQService _rabbitMQService;

        public WhatsAppProvider(IRabbitMQService rabbitMQService)
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
            _rabbitMQService.PublishMessage("whatsapp_queue", request);
        }

        public Task Update(ISendable request)
        {
            throw new NotImplementedException();
        }
    }
}

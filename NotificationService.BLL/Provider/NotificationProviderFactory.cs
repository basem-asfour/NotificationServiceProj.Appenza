using Microsoft.Extensions.DependencyInjection;
using NotificationService.Interface;
using NotificationService.Model.NotificationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.BLL.Provider
{
    public class NotificationProviderFactory : INotificationProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public INotificationProvider GetProvider(Type providerType)
        {
            return providerType switch
            {
                var value when value == typeof(EmailRequest) => _serviceProvider.GetRequiredService<EmailProvider>(),
                var value when value == typeof(SmsRequest) => _serviceProvider.GetRequiredService<SMSProvider>(),
                var value when value == typeof(WhatsAppRequest) => _serviceProvider.GetRequiredService<WhatsAppProvider>(),
                _ => _serviceProvider.GetRequiredService<NotificationProvider>(),
            };
        }
    }
}

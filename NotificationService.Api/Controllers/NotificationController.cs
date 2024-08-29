using Microsoft.AspNetCore.Mvc;
using NotificationService.Interface;
using NotificationService.Model.NotificationModels;

namespace NotificationService.Api.Controllers
{
    [ApiController]
    [Route("v1/notification")]
    public class NotificationController : ControllerBase
    {

        private readonly INotificationProviderFactory _providerFactory;

        public NotificationController(INotificationProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        [HttpPost("send_sms")]
        public async Task<IActionResult> SendSms([FromBody] SmsRequest request)
        {
            await _providerFactory.GetProvider(typeof(SmsRequest)).SendAsync(request);
            return Ok("SMS sent successfully.");
        }

        [HttpPost("send_email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            await _providerFactory.GetProvider(typeof(EmailRequest)).SendAsync(request);
            return Ok("Email sent successfully.");
        }

        [HttpPost("send_whatsapp")]
        public async Task<IActionResult> SendWhatsApp([FromBody] WhatsAppRequest request)
        {
            await _providerFactory.GetProvider(typeof(WhatsAppRequest)).SendAsync(request);
            return Ok("WhatsApp message sent successfully.");
        }

        [HttpPost("send_push")]
        public async Task<IActionResult> SendPushNotification([FromBody] PushNotificationRequest request)
        {
            await _providerFactory.GetProvider(typeof(PushNotificationRequest)).SendAsync(request);
            return Ok("Push notification sent successfully.");
        }
    }

}

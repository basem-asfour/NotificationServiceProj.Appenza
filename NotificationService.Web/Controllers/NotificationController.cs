using Microsoft.AspNetCore.Mvc;
using NotificationService.Web.Interfaces;
using NotificationService.Web.Models;

namespace NotificationService.Web.Controllers
{
    [ApiController]
    [Route("v1/notification")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send_sms")]
        public async Task<IActionResult> SendSms([FromBody] SmsRequest request)
        {
            await _notificationService.SendSmsAsync(request);
            return Ok("SMS sent successfully.");
        }

        [HttpPost("send_email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            await _notificationService.SendEmailAsync(request);
            return Ok("Email sent successfully.");
        }

        [HttpPost("send_whatsapp")]
        public async Task<IActionResult> SendWhatsApp([FromBody] WhatsAppRequest request)
        {
            await _notificationService.SendWhatsAppAsync(request);
            return Ok("WhatsApp message sent successfully.");
        }

        [HttpPost("send_push")]
        public async Task<IActionResult> SendPushNotification([FromBody] PushNotificationRequest request)
        {
            await _notificationService.SendPushNotificationAsync(request);
            return Ok("Push notification sent successfully.");
        }
    }

}

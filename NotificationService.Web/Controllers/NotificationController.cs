﻿using Microsoft.AspNetCore.Mvc;
using NotificationService.Interface;
using NotificationService.Model.NotificationModels;

namespace NotificationService.Web.Controllers
{
    [ApiController]
    [Route("v1/notification")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationProvider _notificationService;

        public NotificationController(INotificationProvider notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send_sms")]
        public async Task<IActionResult> SendSms([FromBody] SmsRequest request)
        {
            await _notificationService.SendAsync(request);
            return Ok("SMS sent successfully.");
        }

        [HttpPost("send_email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            await _notificationService.SendAsync(request);
            return Ok("Email sent successfully.");
        }

        [HttpPost("send_whatsapp")]
        public async Task<IActionResult> SendWhatsApp([FromBody] WhatsAppRequest request)
        {
            await _notificationService.SendAsync(request);
            return Ok("WhatsApp message sent successfully.");
        }

        [HttpPost("send_push")]
        public async Task<IActionResult> SendPushNotification([FromBody] PushNotificationRequest request)
        {
            await _notificationService.SendAsync(request);
            return Ok("Push notification sent successfully.");
        }
    }

}

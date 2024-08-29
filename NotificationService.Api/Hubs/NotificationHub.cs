﻿using Microsoft.AspNetCore.SignalR;

namespace NotificationService.Web.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }

}

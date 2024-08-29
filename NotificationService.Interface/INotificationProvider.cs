namespace NotificationService.Interface
{
    public interface INotificationProvider
    {
        Task SendAsync(ISendable request);

    }


}

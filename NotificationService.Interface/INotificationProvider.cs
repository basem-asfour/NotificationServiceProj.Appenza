namespace NotificationService.Interface
{
    public interface INotificationProvider
    {
        Task SendAsync(ISendable request);
        List<ISendable> GetAll();
        ISendable GetSingle(long id);
        Task Update(ISendable request);

    }


}

namespace NotificationService.Web.Interfaces
{
    public interface IRabbitMQService
    {
        void PublishMessage(string queueName, object message);
        void ConsumeQueue(string queueName, Action<string> onMessageReceived);

    }
}

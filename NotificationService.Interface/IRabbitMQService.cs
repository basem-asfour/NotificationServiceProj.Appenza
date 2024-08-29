namespace NotificationService.Interface
{
    public interface IRabbitMQService
    {
        void PublishMessage(string queueName, object message);
        void ConsumeQueue(string queueName, Action<string> onMessageReceived);

    }
}

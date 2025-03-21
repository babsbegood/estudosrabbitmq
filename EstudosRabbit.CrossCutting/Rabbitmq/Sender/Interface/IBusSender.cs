namespace EstudosRabbit.CrossCutting.Rabbitmq.Sender.Interface
{
    public interface IBusSender
    {
        Task SendMessageAsync<TMessage>(TMessage message) where TMessage : class;
        Task SendMessageToTopicAsync<TMessage>(TMessage message, string routingKey) where TMessage : class;
    }
}

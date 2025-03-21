namespace EstudosRabbit.CrossCutting.Rabbitmq.Sender.Interface
{
    public interface IBusSender
    {
        Task SendMessageAssync<TMessage>(TMessage message) where TMessage : class;
    }
}

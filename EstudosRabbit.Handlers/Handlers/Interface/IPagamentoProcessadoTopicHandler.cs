using EstudosRabbit.Core.Event;

namespace EstudosRabbit.Handlers.Handlers.Interface
{
    public interface IPagamentoProcessadoTopicHandler
    {
        Task Handle(TopicEvent message);
    }
}

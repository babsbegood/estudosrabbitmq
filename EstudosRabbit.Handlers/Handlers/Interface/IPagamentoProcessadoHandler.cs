using EstudosRabbit.Core.Event;

namespace EstudosRabbit.Handlers.Handlers.Interface
{
    public interface IPagamentoProcessadoHandler
    {
        Task Handle(FanoutEvent message);
    }
}

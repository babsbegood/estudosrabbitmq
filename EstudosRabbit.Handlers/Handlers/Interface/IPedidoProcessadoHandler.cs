using EstudosRabbit.Core.Event;

namespace EstudosRabbit.Handlers.Handlers.Interface
{
    public interface IPedidoProcessadoHandler
    {
        Task Handle(FanoutEvent message);
    }
}

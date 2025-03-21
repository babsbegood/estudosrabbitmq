using EstudosRabbit.Core.Event;

namespace EstudosRabbit.Handlers.Handlers.Interface
{
    public interface IPagamentoProcessadoDirectHandler
    {
        Task Handle(DirectEvent message);
    }
}

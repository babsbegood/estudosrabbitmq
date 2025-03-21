using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using MassTransit;

namespace EstudosRabbit.Handlers.Consumers
{
    public class PagamentoProcessadoDirectConsumer : IConsumer<DirectEvent>
    {
        private readonly IPagamentoProcessadoDirectHandler _pagamentoProcessadoDirectHandler;
        public PagamentoProcessadoDirectConsumer(IPagamentoProcessadoDirectHandler pagamentoProcessadoDirectHandler)
        {
            _pagamentoProcessadoDirectHandler = pagamentoProcessadoDirectHandler;
        }
        public async Task Consume(ConsumeContext<DirectEvent> context)
        {
            var message = context.Message;
            await _pagamentoProcessadoDirectHandler.Handle(message);
        }
    }
}

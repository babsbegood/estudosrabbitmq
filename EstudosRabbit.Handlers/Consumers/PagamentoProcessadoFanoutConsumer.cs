using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using MassTransit;

namespace EstudosRabbit.Handlers.Consumers
{
    public class PagamentoProcessadoFanoutConsumer : IConsumer<FanoutEvent>
    {
        private readonly IPagamentoProcessadoHandler _pagamentoProcessadoHandler;
        public PagamentoProcessadoFanoutConsumer(IPagamentoProcessadoHandler pagamentoProcessadoHandler)
        {
            _pagamentoProcessadoHandler = pagamentoProcessadoHandler;
        }
        public async Task Consume(ConsumeContext<FanoutEvent> context)
        {
            var message = context.Message;
            await _pagamentoProcessadoHandler.Handle(message);
        }
    }
}

using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using MassTransit;

namespace EstudosRabbit.Handlers.Consumers
{
    public class PedidoProcessadoFanoutConsumer : IConsumer<FanoutEvent>
    {
        private readonly IPedidoProcessadoHandler _pedidoProcessadoHandler;
        public PedidoProcessadoFanoutConsumer(IPedidoProcessadoHandler pedidoProcessadoHandler)
        {
            _pedidoProcessadoHandler = pedidoProcessadoHandler;
        }
        public async Task Consume(ConsumeContext<FanoutEvent> context)
        {
            var message = context.Message;
            await _pedidoProcessadoHandler.Handle(message);
        }
    }
}

using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using MassTransit;

namespace EstudosRabbit.Handlers.Consumers
{
    public class PagamentoProcessadoTopicConsumer : IConsumer<TopicEvent>
    {
        private readonly IPagamentoProcessadoTopicHandler _pagamentoProcessadoTopicHandler;
        public PagamentoProcessadoTopicConsumer(IPagamentoProcessadoTopicHandler pagamentoProcessadoTopicHandler)
        {
            _pagamentoProcessadoTopicHandler = pagamentoProcessadoTopicHandler;
        }
        public async Task Consume(ConsumeContext<TopicEvent> context)
        {
            var message = context.Message;
            await _pagamentoProcessadoTopicHandler.Handle(message);
        }
    }
}

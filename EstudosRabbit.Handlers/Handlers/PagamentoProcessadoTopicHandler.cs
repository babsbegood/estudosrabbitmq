using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using Microsoft.Extensions.Logging;

namespace EstudosRabbit.Handlers.Handlers
{
    public class PagamentoProcessadoTopicHandler : IPagamentoProcessadoTopicHandler
    {
        private readonly ILogger<string> _logger;
        public PagamentoProcessadoTopicHandler(ILogger<string> logger)
        {
            _logger = logger;
        }
        public async Task Handle(TopicEvent message)
        {
            _logger.LogInformation($"{message}");
            await Task.CompletedTask;
        }
    }
}

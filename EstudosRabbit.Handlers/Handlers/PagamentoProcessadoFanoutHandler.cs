using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using Microsoft.Extensions.Logging;

namespace EstudosRabbit.Handlers.Handlers
{
    public class PagamentoProcessadoFanoutHandler : IPagamentoProcessadoHandler
    {
        private readonly ILogger<string> _logger;

        public PagamentoProcessadoFanoutHandler(ILogger<string> logger)
        {
            _logger = logger;
        }
        public async Task Handle(FanoutEvent message)
        {
            _logger.LogInformation($"{message}");
            await Task.CompletedTask;
        }
    }
}



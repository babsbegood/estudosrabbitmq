using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using Microsoft.Extensions.Logging;

namespace EstudosRabbit.Handlers.Handlers
{
    public class PagamentoProcessadoDirectHandler : IPagamentoProcessadoDirectHandler
    {

        private readonly ILogger<string> _logger;
        public PagamentoProcessadoDirectHandler(ILogger<string> logger)
        {
            _logger = logger;
        }
        public async Task Handle(DirectEvent message)
        {
            await Task.Run(() =>
            {
                _logger.LogInformation($"{message}");
            });
        }
    }
}

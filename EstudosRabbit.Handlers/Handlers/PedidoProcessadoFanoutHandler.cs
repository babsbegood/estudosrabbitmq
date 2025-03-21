using EstudosRabbit.Core.Event;
using EstudosRabbit.Handlers.Handlers.Interface;
using Microsoft.Extensions.Logging;

namespace EstudosRabbit.Handlers.Handlers
{
    public class PedidoProcessadoFanoutHandler : IPedidoProcessadoHandler
    {
        private readonly ILogger<string> _logger;
        public PedidoProcessadoFanoutHandler(ILogger<string> logger)
        {
            _logger = logger;
        }
        public async Task Handle(FanoutEvent message)
        {
            await Task.Run(() =>
            {
                _logger.LogInformation($"{message}");
            });
        }
    }
}

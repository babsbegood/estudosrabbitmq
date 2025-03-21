using EstudosRabbit.Core.Event;
using EstudosRabbit.CrossCutting.Rabbitmq.Sender.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EstudosRabbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private IBusSender _busSender;
        public RabbitController(IBusSender busSender)
        {
            _busSender = busSender;
        }

        [HttpPost("ProcessarPedidoFanout")]
        public async Task<IActionResult> ProcessarPedidoFanout()
        {

            var fanoutEvent = new FanoutEvent(Guid.NewGuid(), "evento fanout");

            await _busSender.SendMessageAssync(fanoutEvent);

            return Ok();
        }


        [HttpPost("ProcessarPedidoDirect")]
        public async Task<IActionResult> ProcessarPedidoDirect()
        {

            var directEvent = new DirectEvent(Guid.NewGuid(), "evento direct");

            await _busSender.SendMessageAssync(directEvent);

            return Ok();
        }
    }
}

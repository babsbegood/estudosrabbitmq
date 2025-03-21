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

            var fanoutEvent = new FanoutEvent(Guid.NewGuid(), "exchange fanout");

            await _busSender.SendMessageAsync(fanoutEvent);

            return Ok();
        }


        [HttpPost("ProcessarPedidoDirect")]
        public async Task<IActionResult> ProcessarPedidoDirect()
        {

            var directEvent = new DirectEvent(Guid.NewGuid(), "exchange direct");

            await _busSender.SendMessageAsync(directEvent);

            return Ok();
        }

        [HttpPost("ProcessarPedidoTopicOrderCreated")]
        public async Task<IActionResult> ProcessarPedidoTopicOrderCreated()
        {

            var topicEvent = new TopicEvent(Guid.NewGuid(), "exchange topic");

            string routingKey = "order.created";

            await _busSender.SendMessageToTopicAsync(topicEvent, routingKey);

            return Ok();
        }

        [HttpPost("ProcessarPedidoTopicOrderUpdated")]
        public async Task<IActionResult> ProcessarPedidoTopicOrderUpdated()
        {

            var topicEvent = new TopicEvent(Guid.NewGuid(), "exchange topic");

            string routingKey = "order.updated";

            await _busSender.SendMessageToTopicAsync(topicEvent, routingKey);

            return Ok();
        }
    }
}

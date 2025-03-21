﻿using EstudosRabbit.CrossCutting.Rabbitmq.Sender.Interface;
using MassTransit;

namespace EstudosRabbit.CrossCutting.Rabbitmq.Sender
{
    public class BusSender : IBusSender
    {
        private readonly IBus _bus;
        public BusSender(IBus bus)
        {
            _bus = bus;
        }

        public async Task SendMessageAsync<TMessage>(TMessage message) where TMessage : class
        {
            await _bus.Publish(message);
        }

        public async Task SendMessageToTopicAsync<TMessage>(TMessage message, string routingKey) where TMessage : class
        {
            await _bus.Publish(message, context =>
            {
                context.SetRoutingKey(routingKey);
            });
        }
    }
}

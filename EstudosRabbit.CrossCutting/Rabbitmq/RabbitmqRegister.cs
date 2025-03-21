using EstudosRabbit.Handlers.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstudosRabbit.CrossCutting.Rabbitmq
{
    public static class RabbitmqRegister
    {
        public static void RegisterRabbitMQService(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitHost = configuration["RabbitHost"] ?? throw new ArgumentNullException("Missing rabbitmq configuration");
            var rabbitUser = configuration["RabbitUser"] ?? throw new ArgumentNullException("Missing rabbitmq configuration");
            var rabbitPwd = configuration["RabbitPwd"] ?? throw new ArgumentNullException("Missing rabbitmq configuration");

            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<PedidoProcessadoFanoutConsumer>();
                busConfigurator.AddConsumer<PagamentoProcessadoFanoutConsumer>();
                busConfigurator.AddConsumer<PagamentoProcessadoDirectConsumer>();
                busConfigurator.AddConsumer<PagamentoProcessadoTopicConsumer>();

                busConfigurator.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri(rabbitHost), host =>
                    {
                        host.Username(rabbitUser);
                        host.Password(rabbitPwd);
                    });

                    #region FANOUT

                    cfg.ReceiveEndpoint("order-queue", e =>
                    {
                        e.Bind("payment-exchange", x =>
                        {
                            x.ExchangeType = "fanout";
                        });

                        e.ConfigureConsumer<PedidoProcessadoFanoutConsumer>(ctx);
                    });


                    cfg.ReceiveEndpoint("order-notification-queue", e =>
                    {
                        e.Bind("payment-exchange", x =>
                        {
                            x.ExchangeType = "fanout";
                        });

                        e.ConfigureConsumer<PagamentoProcessadoFanoutConsumer>(ctx);
                    });

                    #endregion


                    #region DIRECT

                    cfg.ReceiveEndpoint("order-direct-queue", e =>
                    {
                        e.Bind("order-direct-exchange", x =>
                        {
                            x.ExchangeType = "direct";
                        });

                        e.ConfigureConsumer<PagamentoProcessadoDirectConsumer>(ctx);
                    });

                    #endregion

                    #region TOPIC

                    cfg.ReceiveEndpoint("order-topic-queue", e =>
                    {
                        e.Bind("order-topic-exchange", x =>
                        {
                            x.ExchangeType = "topic";
                            x.RoutingKey = "order.*";
                        });
                        e.ConfigureConsumer<PagamentoProcessadoTopicConsumer>(ctx);
                    });

                    #endregion
                });
            });
        }
    }
}

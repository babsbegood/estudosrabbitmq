using EstudosRabbit.CrossCutting.Rabbitmq.Sender;
using EstudosRabbit.CrossCutting.Rabbitmq.Sender.Interface;
using EstudosRabbit.Handlers.Handlers;
using EstudosRabbit.Handlers.Handlers.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace EstudosRabbit.CrossCutting.IoC
{
    public static class DependecyRegister
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IBusSender, BusSender>();

            services.AddScoped<IPedidoProcessadoHandler, PedidoProcessadoFanoutHandler>();
            services.AddScoped<IPagamentoProcessadoHandler, PagamentoProcessadoFanoutHandler>();
            services.AddScoped<IPagamentoProcessadoDirectHandler, PagamentoProcessadoDirectHandler>();
            return services;
        }
    }
}

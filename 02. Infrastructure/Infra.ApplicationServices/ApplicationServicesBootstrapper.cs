using Infra.ApplicationServices.Commands.ProductAggregate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.ApplicationServices
{
    public static class ApplicationServicesBootstrapper
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}

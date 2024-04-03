using Microsoft.Extensions.DependencyInjection;

namespace RetroSpec.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static RetroBuilder AddRetroSpec(this IServiceCollection services)
    {
        return new(services);
    }
}

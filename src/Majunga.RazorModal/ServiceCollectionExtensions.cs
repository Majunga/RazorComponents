using Microsoft.Extensions.DependencyInjection;

namespace Majunga.RazorModal
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorModal(this IServiceCollection services)
        {
            return services.AddScoped<IModalService, ModalService>();
        }
    }
}

using Application.Interfaces;
using Application.Services;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuting.Native_Injector;

public static class NativeInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}
using colecaohq.API.Extension;
using colecaohq.Business.Interface;
using colecaohq.Business.Notificacoes;
using colecaohq.Business.Services;
using colecaohq.Data.Context;
using colecaohq.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace colecaohq.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped<IEditoraRepository, EditoraRepository>();
            services.AddScoped<IEquipePerssonagem, EquipePerssonagemRepository>();
            services.AddScoped<IHqPerssonagem, HqPerssonagemRepository>();
            services.AddScoped<ITituloHq, TituloHqRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IEditoraService, EditoraService>();
            services.AddScoped<IEquipePerssonagemService, EquipePerssonagemService>();
            services.AddScoped<IHqPerssonagemService, HqPerssonagemService>();
            services.AddScoped<ITituloHqService, TituloHqService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}

using NSE.Catalogo.API.Data;

namespace NSE.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<CatalogoContext>();
        }
    }
}

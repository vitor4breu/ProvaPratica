using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Mensagem;
using Infrastructure;
using Infrastructure.Repositories;
using Service.Services;

namespace AplicativoWebProvaRemota
{
    public static class Configuracao
    {
        public static void Configurar(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            ServicesConfiguration.AddScoped<ICrudService, CrudService>();
            ServicesConfiguration.AddScoped<IMensagem, Mensagem>();
            ServicesConfiguration.AddSingleton<ConexaoBanco>();
        }
    }
}

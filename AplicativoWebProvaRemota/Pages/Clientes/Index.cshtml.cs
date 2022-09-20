using Dominio.Interfaces.Servicos;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicativoWebProvaRemota.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        public List<Cliente> Clientes = new List<Cliente>();
        private readonly ICrudService _servico;


        public IndexModel(ICrudService servico)
        {
            _servico = servico;
        }

        public async Task OnGetAsync()
        {
            Clientes.AddRange(await _servico.ListarClientes());
        }
    }
}

using Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicativoWebProvaRemota.Pages.Clientes
{
    public class DeletarModel : PageModel
    {
        public ICrudService _service { get; set; }
        public DeletarModel(ICrudService service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }
    }
}

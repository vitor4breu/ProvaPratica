using Dominio.Interfaces.Servicos;
using Dominio.Mensagem;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services;

namespace AplicativoWebProvaRemota.Pages.Clientes
{
    public class EditarModel : PageModel
    {
        public Cliente Cliente = new() { SituacaoId = 1, TipoId = 1  };
        public ICrudService _service { get; }
        public IMensagem _mensagem { get; }

        public EditarModel(ICrudService service, IMensagem mensagem)
        {
            _service = service;
            _mensagem = mensagem;
        }

        public async Task OnGet()
        {
            string cpf = Request.Query["cpf"];
            Cliente = await _service.ObterClientePorCpf(cpf);
        }

        public void OnPost()
        {
            
            Cliente.CPF = Request.Query["cpf"];
            Cliente.Nome = Request.Form["Nome"];
            Cliente.SituacaoId = int.Parse(Request.Form["Situacao"]);
            Cliente.TipoId = int.Parse(Request.Form["Tipo"]);
            Cliente.Sexo = Request.Form["Sexo"];

            if (!_mensagem.PossuiErros)
            {
                _service.AtualizarCliente(Cliente);
                if (!_mensagem.PossuiErros)
                {
                    _mensagem.AdicionarMensagem("Cliente editado com sucesso");
                }
                }
        }
    }
}

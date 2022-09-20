using Dominio.Interfaces.Servicos;
using Dominio.Mensagem;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Services;

namespace AplicativoWebProvaRemota.Pages.Clientes
{
    public class CriarModel : PageModel
    {
        public Cliente Cliente = new() { SituacaoId = 1, TipoId = 1 };
        public ICrudService _service { get; }
        public IMensagem _mensagem { get; }

        public CriarModel(ICrudService service, IMensagem mensagem)
        {
            _service = service;
            _mensagem = mensagem;
        }

        public void OnPost()
        {
            Cliente.Nome = Request.Form["Nome"];
            Cliente.CPF = Request.Form["Cpf"];
            Cliente.SituacaoId = int.Parse(Request.Form["Situacao"]);
            Cliente.TipoId = int.Parse(Request.Form["Tipo"]);
            Cliente.Sexo = Request.Form["Sexo"];

            if (!_mensagem.PossuiErros)
            {
                _service.AdicionarCliente(Cliente);
                _mensagem.AdicionarMensagem("Cliente adicionado com sucesso");
            }
        }
    }
}

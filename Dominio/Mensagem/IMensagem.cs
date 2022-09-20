using System.Collections.Generic;

namespace Dominio.Mensagem
{
    public interface IMensagem
    {
        bool PossuiErros { get; }
        bool PossuiMensagens { get; }
        void AdicionarErro(string mensagem);
        void AdicionarMensagem(string mensagem);

        List<string> BuscarErros();
        List<string> BuscarMensagens();
    }
}

using System.Collections.Generic;

namespace Dominio.Mensagem
{
    public class Mensagem : IMensagem
    {
        private readonly List<string> _erros;
        private readonly List<string> _mensagens;
        public Mensagem()
        {
            _erros = new List<string>();
            _mensagens = new List<string>();
        }
        public bool PossuiErros => _erros.Count > 0;
        public bool PossuiMensagens => _mensagens.Count > 0;

        public void AdicionarErro(string mensagem) => _erros.Add(mensagem);
        public void AdicionarMensagem(string mensagem) => _mensagens.Add(mensagem);
        
        public List<string> BuscarErros() => _erros;
        public List<string> BuscarMensagens() => _mensagens;
        

    }
}


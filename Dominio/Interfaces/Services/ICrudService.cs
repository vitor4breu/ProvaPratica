using Dominio.Models;

namespace Dominio.Interfaces.Servicos
{
    public interface ICrudService
    {
        public Task<IEnumerable<Cliente>> ListarClientes();
        public Task<bool> AtualizarCliente(Cliente cliente);
        public Task<bool> DeletarCliente(string Cpf);
        public Task<bool> AdicionarCliente(Cliente cliente);
        public Task<Cliente> ObterClientePorCpf(string cpf);
    }
}

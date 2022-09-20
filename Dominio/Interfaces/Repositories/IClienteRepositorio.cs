using Dominio.Models;

namespace Dominio.Interfaces.Repositorios
{
    public interface IClienteRepositorio
    {
        public Task<IEnumerable<Cliente>> BuscarClientes();
        public Task<Cliente> BuscarClientePorCpf(string cpf);
        public Task<bool> AdicionarCliente(Cliente cliente);
        public Task<bool> AtualizarCliente(Cliente cliente);
        public Task<bool> DeletarCliente(string cpf);
    }
}

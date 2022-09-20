using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Models;

namespace Service.Services
{
    public class CrudService : ICrudService
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public CrudService
            (
            IClienteRepositorio clienteRepositorio
            )
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Task<bool> AdicionarCliente(Cliente cliente) =>
            _clienteRepositorio.AdicionarCliente(cliente);

        public Task<bool> AtualizarCliente(Cliente cliente) =>
            _clienteRepositorio.AtualizarCliente(cliente);

        public Task<bool> DeletarCliente(string Cpf) =>
            _clienteRepositorio.DeletarCliente(Cpf);

        public Task<IEnumerable<Cliente>> ListarClientes() =>
            _clienteRepositorio.BuscarClientes();

        public Task<Cliente> ObterClientePorCpf(string cpf) =>
            _clienteRepositorio.BuscarClientePorCpf(cpf);
        
    }
}

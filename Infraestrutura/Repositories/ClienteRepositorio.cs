using Dapper;
using Dominio.Interfaces.Repositorios;
using Dominio.Mensagem;
using Dominio.Models;
using System.Data;
using System.Data.Common;

namespace Infrastructure.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ConexaoBanco _connection;
        private readonly IMensagem _mensagem;

        public ClienteRepositorio(ConexaoBanco connection, IMensagem mensagem)
        {
            _connection = connection;
            _mensagem = mensagem;
        }

        public async Task<IEnumerable<Cliente>> BuscarClientes()
        {
            using DbConnection connection = _connection.Sql;

            const string sqlCommand = @"
                SELECT Nome, Cpf, Tipo_id as TipoId, Sexo, Situacao_id as SituacaoId FROM CLIENTE
            ";
            return await connection.QueryAsync<Cliente>(sqlCommand);
        }

        public async Task<Cliente> BuscarClientePorCpf(string cpf)
        {
            using DbConnection connection = _connection.Sql;

            var parametros = new DynamicParameters();
            parametros.Add("@cpf", cpf, DbType.String, size: 11);

            const string sqlCommand = @"
                SELECT Nome, Cpf, Tipo_id as TipoId, Sexo, Situacao_id as SituacaoId FROM CLIENTE
                WHERE CPF = @CPF
            ";
            return await connection.QueryFirstOrDefaultAsync<Cliente>(sqlCommand, parametros);
        }

        public async Task<bool> AtualizarCliente(Cliente clienteAtualizado)
        {
            using DbConnection connection = _connection.Sql;

            var parametros = new DynamicParameters();
            parametros.Add("@cpf", clienteAtualizado.CPF, DbType.String, size: 11);
            parametros.Add("@nome", clienteAtualizado.Nome, DbType.String, size: 11);
            parametros.Add("@situacao", clienteAtualizado.SituacaoId, DbType.Decimal, size: 2);
            parametros.Add("@tipo", clienteAtualizado.TipoId, DbType.Decimal, size: 2);
            parametros.Add("@sexo", clienteAtualizado.Sexo, DbType.String, size: 1);

            const string sqlProc = "execute sp_Atualizar_Cliente @nome, @cpf, @tipo, @sexo, @situacao";
            try
            {
                var retorno = await connection.ExecuteAsync(sqlProc, parametros);
                return retorno > 0;
            }
            catch (Exception ex)
            {
                _mensagem.AdicionarErro(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeletarCliente(string cpf)
        {
            using DbConnection connection = _connection.Sql;

            var parametros = new DynamicParameters();
            parametros.Add("@cpf", cpf, DbType.String, size: 11);

            const string sqlProc = "execute sp_Remover_Cliente @cpf";
            try
            {
                var retorno = await connection.ExecuteAsync(sqlProc, parametros);
                return retorno > 0;
            }
            catch (Exception ex)
            {
                _mensagem.AdicionarErro(ex.Message);
                return false;
            }
        }

        public async Task<bool> AdicionarCliente(Cliente clienteAtualizado)
        {
            using DbConnection connection = _connection.Sql;

            var parametros = new DynamicParameters();
            parametros.Add("@cpf", clienteAtualizado.CPF, DbType.String, size: 11);
            parametros.Add("@nome", clienteAtualizado.Nome, DbType.String, size: 11);
            parametros.Add("@situacao", clienteAtualizado.SituacaoId, DbType.Decimal, size: 2);
            parametros.Add("@tipo", clienteAtualizado.TipoId, DbType.Decimal, size: 2);
            parametros.Add("@sexo", clienteAtualizado.Sexo, DbType.String, size: 1);

            const string sqlProc = "execute sp_Adicionar_Cliente @nome, @cpf, @tipo, @sexo, @situacao";
            try
            {
                var retorno = await connection.ExecuteAsync(sqlProc, parametros);
                return retorno > 0;
            }
            catch (Exception ex)
            {
                _mensagem.AdicionarErro(ex.Message);
                return false;
            }
        }
    }
}

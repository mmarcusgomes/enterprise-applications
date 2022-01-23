using NSE.Clientes.API.Models;
using NSE.Core.Data;

namespace NSE.Clientes.API.Data.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);

        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
    }
}
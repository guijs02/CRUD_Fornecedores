using Model.Model;

namespace SistemaWeb.API.Repository.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> ObterTodos();
        Task<Fornecedor> ObterPorId(int id);
        Task<Fornecedor> Adicionar(Fornecedor fornecedor);
        Task<Fornecedor> Alterar(Fornecedor fornecedor);
        Task<bool> Deletar(int id);
    }
}

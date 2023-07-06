using Model.Model;

namespace SistemaWeb.API.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<List<Fornecedor>> ObterTodos();
        Task<Fornecedor> ObterPorId(int id);
        Task<Fornecedor> Adicionar(Fornecedor fornecedor);
        Task<Fornecedor> Alterar(Fornecedor fornecedor);
        Task<bool> Deletar(int id);
    }
}

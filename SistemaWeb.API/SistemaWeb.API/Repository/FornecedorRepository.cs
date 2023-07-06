using Microsoft.EntityFrameworkCore;
using Model.Model;
using SistemaWeb.API.Context;
using SistemaWeb.API.Repository.Interfaces;

namespace SistemaWeb.API.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppContextData _db;
        public FornecedorRepository(AppContextData db)
        {
            _db = db;
        }
        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            _db.Fornecedor.Add(fornecedor);
            await _db.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> Alterar(Model.Model.Fornecedor fornecedor)
        {
            _db.Fornecedor.Update(fornecedor);
            await _db.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<bool> Deletar(int id)
        {
            var obj = _db.Fornecedor.FirstOrDefault(x => x.Id == id);
            _db.Fornecedor.Remove(obj);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Fornecedor> ObterPorId(int id)
        {
            return await _db.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);
           
        }

        public async Task<List<Fornecedor>> ObterTodos()
        {
            return await _db.Fornecedor.ToListAsync();
        }
    }
}

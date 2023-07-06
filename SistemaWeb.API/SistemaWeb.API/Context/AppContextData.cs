using Microsoft.EntityFrameworkCore;
using Model.Model;

namespace SistemaWeb.API.Context
{
    public class AppContextData : DbContext
    {
        public AppContextData(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}

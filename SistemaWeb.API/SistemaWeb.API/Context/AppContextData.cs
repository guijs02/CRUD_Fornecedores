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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer("Server=DESKTOP-E5GDEOV\\SQLEXPRESS;Database=FornecedorDb; Encrypt = False; Integrated Security = True;");
        }
    }
}

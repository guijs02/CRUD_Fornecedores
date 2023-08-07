using Microsoft.EntityFrameworkCore;
using SistemaWeb.API.Context;

namespace CrudFornecedorTest
{
    public class ConnectionDb
    {

        [Fact]
        public void TestarConexaoComBd()
        {
            try
            {
                DbContextOptions options = new DbContextOptionsBuilder<AppContextData>().Options;
                AppContextData context = new(options);

                var conectado = context.Database.CanConnect();

                Assert.True(conectado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}

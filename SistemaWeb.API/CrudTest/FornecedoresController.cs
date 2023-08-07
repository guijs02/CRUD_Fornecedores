using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using SistemaWeb.API.Context;
using SistemaWeb.API.Controllers;
using SistemaWeb.API.Repository;
using Moq;
using SistemaWeb.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CrudFornecedorTest
{
    public class FornecedoresController
    {
        private readonly DbContextOptions options;
        private readonly AppContextData context;
        private readonly FornecedorRepository repo;
        private readonly FornecedorController controller;
        public FornecedoresController()
        {
            options = new DbContextOptionsBuilder<AppContextData>().UseInMemoryDatabase("AppContextData").Options;
            context = new AppContextData(options);
            repo = new FornecedorRepository(context);
            controller = new FornecedorController(repo);
        }
        [Fact]
        private void TestarConexaoComBanco()
        {
            var conexao = context.Database.CanConnect();

            Assert.True(conexao);
        }

        private async Task<Fornecedor> InitAddObjectDb()
        {
            var fornecedor = new Fornecedor()
            {
                Id = default,
                Cep = "25689748",
                Cnpj = "15484845482",
                Endereco = "rua 3, numero 123, Jd das Palmeiras",
                Especialidade = Model.Enum.EEspecialidade.Servico,
                Nome = "Pogba"
            };
            await controller.Adicionar(fornecedor);

            return fornecedor;
        }
        [Fact]
        public async Task TestarControladorInclusao()
        {

            var fornecedor = new Fornecedor()
            {
                Id = 0,
                Cep = "25689748",
                Cnpj = "15484845482",
                Endereco = "rua 3, numero 123, Jd das Palmeiras",
                Especialidade = Model.Enum.EEspecialidade.Comercio,
                Nome = "Alexandre Pato"
            };

            var response = await controller.Adicionar(fornecedor);

            Assert.IsType<OkObjectResult>(response);

        }
        [Fact]
        public async Task TestarControladorDelecao()
        {
            await InitAddObjectDb();
            int id = 1;
            var response = await controller.Deletar(id);

            Assert.IsType<OkObjectResult>(response);

        }
        [Fact]
        public async Task TestarControladorAlteracao()
        {
            var fornecedor = await InitAddObjectDb();

            fornecedor.Especialidade = Model.Enum.EEspecialidade.Industria;
            fornecedor.Cep = "5555510";
            fornecedor.Nome = "BobEsponja";

            var response = await controller.Alterar(fornecedor);

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public async Task TestarControladorInclusaoParaDarErro()
        {
            Fornecedor fornecedor = null;

            await Assert.ThrowsAsync<NullReferenceException>(async () => await controller.Adicionar(fornecedor));

        }
        [Fact]
        public async Task TestarControladorAlteracaoParaDarErro()
        {
            await InitAddObjectDb();

            var fornecedor = new Fornecedor()
            {
                Id = 6,
                Cep = "11111",
                Cnpj = "8888888",
                Endereco = "rua 3, numero 123, Jd das Palmeiras",
                Especialidade = Model.Enum.EEspecialidade.Comercio,
                Nome = "LIONEL MESSI"
            };

            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await controller.Alterar(fornecedor));

        }

        [Fact]
        public async Task TestarControladorDelecaoSeIdNaoExiste()
        {
            int id = 3;

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await controller.Deletar(id));

        }
    }
}

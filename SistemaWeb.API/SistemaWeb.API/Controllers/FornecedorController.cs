using Microsoft.AspNetCore.Mvc;
using Model.Model;
using SistemaWeb.API.Repository.Interfaces;

namespace SistemaWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _repo;
        public FornecedorController(IFornecedorRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var fornecedores = await _repo.ObterTodos();
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var fornecedor = await _repo.ObterPorId(id);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Adicionar(Fornecedor fornecedor)
        {
            try
            {
                var adicionado = await _repo.Adicionar(fornecedor);
                return Ok(adicionado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(Fornecedor fornecedor)
        {
            try
            {
                var alterado = await _repo.Alterar(fornecedor);
                return Ok(alterado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var deletou = await _repo.Deletar(id);
                return Ok(deletou);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
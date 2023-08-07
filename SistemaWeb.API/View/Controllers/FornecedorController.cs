using Microsoft.AspNetCore.Mvc;
using Model.Model;
using SistemaWeb.API.Services.Interfaces;
using System.Diagnostics;


namespace View.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _service;
        public FornecedorController(IFornecedorService service)
        {
            _service = service;
        }

        public IActionResult FornecedorCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FornecedorCreate(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var obj = await _service.Adicionar(fornecedor);
                if (obj is not null)
                {
                    return RedirectToAction(nameof(FornecedorIndex));

                }
            }
            return View(fornecedor);

        }
        public async Task<IActionResult> FornecedorIndex()
        {
            var fornecedores = await _service.ObterTodos();
            return View(fornecedores);
        }
        [HttpGet]
        public async Task<IActionResult> FornecedorUpdate(int id)
        {
            var fornecedor = await _service.ObterPorId(id);
            return View(fornecedor);
        }
        [HttpPost]
        public async Task<IActionResult> FornecedorUpdate(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var obj = await _service.Alterar(fornecedor);
                if (obj is not null)
                {
                    return RedirectToAction(nameof(FornecedorIndex));

                }
            }
            return View(fornecedor);
        }
        public async Task<IActionResult> FornecedorDelete(int id)
        {
            await _service.Deletar(id);
            return RedirectToAction(nameof(FornecedorIndex));
        }
    }
}
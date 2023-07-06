using Microsoft.AspNetCore.Mvc;
using SistemaWeb.API.Services.Interfaces;
using System.Diagnostics;
using View.Models;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFornecedorService _service;
        public HomeController(IFornecedorService service)
        {
            _service = service;
        }
       
        public async Task<IActionResult> Index()
        {
            var fornecedores = await _service.ObterTodos();
            return View(fornecedores);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
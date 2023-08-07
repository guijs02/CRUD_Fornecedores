using Model.Model;
using SistemaWeb.API.Repository.Interfaces;
using SistemaWeb.API.Services.Interfaces;
using SistemaWeb.View.Utils;
using System.Text.Json;

namespace SistemaWeb.API.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly HttpClient _http;
        private const string API = "api/Fornecedor";
 
        public FornecedorService(HttpClient http)
        {
            _http = http;
     
        }

        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            var response = await _http.PostAsJsonAsync(API, fornecedor);
            if (response.IsSuccessStatusCode)
            {
                return await HttpClientExtensions.Desserializador<Fornecedor>(response);
            }
            else
            {
                var erro = HttpClientExtensions.TratarResponse(response);
                throw new Exception(erro);
            }
        }

        public async Task<Fornecedor> Alterar(Fornecedor fornecedor)
        {
            var response = await _http.PutAsJsonAsync(API, fornecedor);
            if (response.IsSuccessStatusCode)
            {
                return await HttpClientExtensions.Desserializador<Fornecedor>(response);
            }
            else
            {

                var erro = HttpClientExtensions.TratarResponse(response);
            throw new Exception(erro);
            }
        }

        public async Task<bool> Deletar(int id)
        {
            var response = await _http.DeleteAsync($"{API}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var erro = HttpClientExtensions.TratarResponse(response);
                throw new Exception(erro);
            }
        }

        public async Task<Fornecedor> ObterPorId(int id)
        {
            var response = await _http.GetAsync($"{API}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await HttpClientExtensions.Desserializador<Fornecedor>(response);
            }
            else
            {

                var erro = HttpClientExtensions.TratarResponse(response);
                throw new Exception(erro);
            }
        }

        public async Task<List<Fornecedor>> ObterTodos()
        {
            var response = await _http.GetAsync(API);

            if (response.IsSuccessStatusCode)
            {
                return await HttpClientExtensions.Desserializador<List<Fornecedor>>(response);
            }
            else
            {
                var erro = HttpClientExtensions.TratarResponse(response);
                throw new Exception(erro);
            }
        }

    }
}

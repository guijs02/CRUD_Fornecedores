using Model.Model;
using SistemaWeb.API.Repository.Interfaces;
using SistemaWeb.API.Services.Interfaces;
using System.Text.Json;

namespace SistemaWeb.API.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly HttpClient _http;
        private const string API = "api/Fornecedor";
        private const string ERROR_API = "Erro ao realizar a requisição na api!";
        private JsonSerializerOptions _options;
        public FornecedorService(HttpClient http)
        {
            _http = http;
            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };
        }

        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            var response = await _http.PostAsJsonAsync(API, fornecedor);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Serializador<Fornecedor>(content);
            }
            else
                throw new Exception(ERROR_API);
        }

        public async Task<Fornecedor> Alterar(Fornecedor fornecedor)
        {
            var response = await _http.PutAsJsonAsync(API, fornecedor);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Serializador<Fornecedor>(content);
            }
            else
                throw new Exception(ERROR_API);
        }

        public async Task<bool> Deletar(int id)
        {
            var response = await _http.DeleteAsync($"{API}/{id}");
            if (response.IsSuccessStatusCode)
                return true;
            else
                throw new Exception(ERROR_API);
        }

        public async Task<Fornecedor> ObterPorId(int id)
        {
            var response = await _http.GetAsync($"{API}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return Serializador<Fornecedor>(content);
            }
            else
                throw new Exception(ERROR_API);
        }

        public async Task<List<Fornecedor>> ObterTodos()
        {
            var response = await _http.GetAsync(API);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return Serializador<List<Fornecedor>>(content);
            }
            else
                throw new Exception(ERROR_API);
        }

        public T Serializador<T>(string content)
        {
            try
            {

                return JsonSerializer.Deserialize<T>(content, _options);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

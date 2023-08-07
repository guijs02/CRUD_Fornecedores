
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SistemaWeb.View.Utils
{
    public class HttpClientExtensions
    {
        private static JsonSerializerOptions _options;
        private const string APPLICATION_JSON = "application/json";

        private const string ERROR_API = "Erro ao realizar a requisição na api!";
        public HttpClientExtensions()
        {
            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };
        }
        public async static Task<T> Desserializador<T>(HttpResponseMessage response)
        {
            try
            {
                MediaTypeHeaderValue mediaType = response.Content.Headers.ContentType;

                if (mediaType is null || mediaType.MediaType != APPLICATION_JSON)
                {
                    throw new FormatException("O formato da resposta não está no tipo adequado");
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<T>(content, _options);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string TratarResponse(HttpResponseMessage responseMessage)
        {
            string response;
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    response = "Erro na requisição";
                    break;
                case HttpStatusCode.InternalServerError:
                    response = "Ocorreu um erro interno no servidor do aplicativo";
                    break;
      
                case HttpStatusCode.NotFound:
                    response = "Não foi encontrado o conteudo";
                    break;
           
                default:
                    {
                        response = ERROR_API;
                        break;
                    }

            }
            return response;
        }

    }
}

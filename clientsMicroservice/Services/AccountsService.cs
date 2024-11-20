
using System.ComponentModel.DataAnnotations;
using ClientsMicroservice.Models.Dtos;
using Newtonsoft.Json;

namespace ClientsMicroservice.Services
{    public class AccountsService 
    {
        private readonly string baseUrl = "http://localhost:5000";
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<object> GetAccountMovemenets(int clientId, DateTime fechaInicio, DateTime fechaFin)
        {
            var client = _httpClientFactory.CreateClient();
            var requestUrl = $"{baseUrl}/api/movimientos/reporte/{clientId}?initialDate={fechaInicio}&endDate={fechaFin}";
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ReportDto>>(jsonString);
            }
            else
            {
                throw new ValidationException("No se encontró movimientos");
            }
        }
    }
}
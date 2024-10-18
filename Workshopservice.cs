using System.Net.Http.Json;
using System.Text.Json;
using warsztat.Models;

namespace warsztat.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly HttpClient _httpClient;

        public WorkshopService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Workshop>> GetWorkshopsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7145/api/workshops");
                response.EnsureSuccessStatusCode(); // Rzuci wyjątek, jeśli status kodu to nie 2xx
                return await response.Content.ReadFromJsonAsync<List<Workshop>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd podczas pobierania warsztatów: {ex.Message}");
                throw;
            }
        }

        public async Task AddWorkshopAsync(Workshop workshop)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7145/api/workshops", workshop);

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Content: {responseContent}");

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteWorkshopAsync(int workshopId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7145/api/workshops/{workshopId}");
            response.EnsureSuccessStatusCode();
        }
    }
}

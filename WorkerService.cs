using System.Net.Http.Json;
using warsztat.Models;
using System.Text.Json;

namespace warsztat.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly HttpClient _httpClient;

        public WorkerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Worker>> GetWorkersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7145/api/workers");
                response.EnsureSuccessStatusCode(); // Rzuci wyjątek, jeśli status kodu to nie 2xx
                return await response.Content.ReadFromJsonAsync<List<Worker>>() ?? new List<Worker>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd podczas pobierania pracowników: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
                throw;
            }
        }

        public async Task AddWorkerAsync(Worker worker)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7145/api/workers", worker);

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Content: {responseContent}");

                response.EnsureSuccessStatusCode(); // Upewniamy się, że żądanie zakończyło się powodzeniem
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd podczas dodawania pracownika: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
                throw;
            }
        }
    }
}

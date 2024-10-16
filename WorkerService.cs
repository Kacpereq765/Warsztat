using System.Net.Http.Json;
using warsztat.Models;
using System.Text.Json;

public class WorkerService : IWorkerService
{
    private readonly HttpClient _httpClient;

    public WorkerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddWorkerAsync(Worker worker)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7145/api/workers", worker);
            response.EnsureSuccessStatusCode(); // Upewniamy się, że żądanie zakończyło się powodzeniem
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

    public async Task<List<Worker>> GetWorkersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://localhost:7145/api/workers");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Worker>>() ?? new List<Worker>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching workers: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            throw;
        }
    }
}

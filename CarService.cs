using System.Net.Http.Json;
using warsztat.Models;

namespace warsztat.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;

        public CarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7145/api/cars");
                response.EnsureSuccessStatusCode(); // Rzuci wyjątek, jeśli status kodu to nie 2xx
                return await response.Content.ReadFromJsonAsync<List<Car>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd podczas pobierania samochodów: {ex.Message}");
                throw;
            }
        }

        public async Task AddCarAsync(Car car)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7145/api/cars", car);

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

        // Metoda do usuwania samochodu po ID
        public async Task DeleteCarAsync(int carId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7145/api/cars/{carId}");

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Content: {responseContent}");

                response.EnsureSuccessStatusCode(); // Sprawdź, czy status odpowiedzi to 2xx
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd podczas usuwania samochodu: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}

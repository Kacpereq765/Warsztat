using warsztat.Models; 
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace warsztat.Services
{
    public interface ICarService
    {
        Task AddCarAsync(Car car);
        Task<List<Car>> GetCarsAsync(); 
    }
}

using warsztat.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace warsztat.Services
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetWorkersAsync();
        Task AddWorkerAsync(Worker worker);
    }
}

using warsztat.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace warsztat.Services
{
    public interface IWorkshopService
    {
        Task AddWorkshopAsync(Workshop workshop);
        Task<List<Workshop>> GetWorkshopsAsync(); 
    }
}

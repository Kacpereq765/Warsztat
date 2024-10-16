using System.Collections.Generic;
using System.Threading.Tasks;
using warsztat.Models;

public interface IWorkerService
{
    Task AddWorkerAsync(Worker worker);

    Task<List<Worker>> GetWorkersAsync();
}

using TextProcess.Backend.Domain.Entities;

namespace TextProcess.Backend.Domain.Services
{
    public interface IRepository<T>
    {        
        Task<T> GetAsync(int id);

      
        Task<IEnumerable<T>> GetAllAsync();
    }
}
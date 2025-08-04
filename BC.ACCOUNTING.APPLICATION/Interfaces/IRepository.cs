using BC.ACCOUNTING.CORE.DTO.General;

namespace BC.ACCOUNTING.APPLICATION.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(DeleteDTO dto);
    }
}

using SchoolAPI.Models;

namespace SchoolAPI.Repositories
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<School>> GetAllAsync();
        Task<School?> GetByIdAsync(int id);
        Task<IEnumerable<School>> SearchByNameAsync(string name);
        Task AddAsync(School school);
        Task UpdateAsync(School school);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task SaveAsync();
    }
}


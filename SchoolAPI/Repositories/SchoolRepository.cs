using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.Repositories
{
    public class SchoolRepository : IUniversityRepository
    {
        private readonly SchoolDbContext _context;

        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<School>> GetAllAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School?> GetByIdAsync(int id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task<IEnumerable<School>> SearchByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await _context.Schools.ToListAsync();

            return await _context.Schools
                .Where(s => s.Name.Contains(name))
                .ToListAsync();
        }

        public async Task AddAsync(School school)
        {
            await _context.Schools.AddAsync(school);
        }

        public Task UpdateAsync(School school)
        {
            _context.Entry(school).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school != null)
            {
                _context.Schools.Remove(school);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Schools.AnyAsync(s => s.Id == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}


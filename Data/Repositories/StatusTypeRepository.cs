using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class StatusTypeRepository
    {
        private readonly DataContext _context;

        public StatusTypeRepository(DataContext context)
        {
            _context = context;
        }

        // CREATE 
        public async Task<StatusTypeEntity> CreateAsync(StatusTypeEntity statusType)
        {
            _context.StatusType.Add(statusType); 
            await _context.SaveChangesAsync();
            return statusType;
        }

        // READ 
        public async Task<IEnumerable<StatusTypeEntity>> GetAllAsync()
        {
            return await _context.StatusType.ToListAsync(); 
        }

        public async Task<StatusTypeEntity?> GetByIdAsync(int id)
        {
            return await _context.StatusType.FirstOrDefaultAsync(s => s.Id == id); 
        }

        // UPDATE 
        public async Task<StatusTypeEntity?> UpdateAsync(StatusTypeEntity updatedStatusType)
        {
            var existingStatus = await _context.StatusType.FirstOrDefaultAsync(s => s.Id == updatedStatusType.Id);
            if (existingStatus != null)
            {
                existingStatus.StatusName = updatedStatusType.StatusName;

                await _context.SaveChangesAsync();
                return existingStatus;
            }
            return null;
        }

        // DELETE 
        public async Task<bool> DeleteAsync(int id)
        {
            var statusType = await _context.StatusType.FirstOrDefaultAsync(s => s.Id == id); 
            if (statusType != null)
            {
                _context.StatusType.Remove(statusType); 
                return true;
            }
            return false;
        }
    }
}

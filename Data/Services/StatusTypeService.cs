using Data.Entities;
using Data.Repositories;

namespace Data.Services
{
    public class StatusTypeService
    {
        private readonly StatusTypeRepository _statusTypeRepository;

        public StatusTypeService(StatusTypeRepository statusTypeRepository)
        {
            _statusTypeRepository = statusTypeRepository;
        }

        // CREATE
        public async Task<StatusTypeEntity> CreateStatusAsync(StatusTypeEntity status)
        {
            return await _statusTypeRepository.CreateAsync(status);
        }

        // READ 
        public async Task<IEnumerable<StatusTypeEntity>> GetAllStatusesAsync()
        {
            return await _statusTypeRepository.GetAllAsync();
        }

  
        public async Task<StatusTypeEntity?> GetStatusByIdAsync(int id)
        {
            return await _statusTypeRepository.GetByIdAsync(id);
        }

        // UPDATE 
        public async Task<StatusTypeEntity?> UpdateStatusAsync(StatusTypeEntity updatedStatus)
        {
            return await _statusTypeRepository.UpdateAsync(updatedStatus);
        }

        // DELETE 
        public async Task<bool> DeleteStatusAsync(int id)
        {
            return await _statusTypeRepository.DeleteAsync(id);
        }
    }
}

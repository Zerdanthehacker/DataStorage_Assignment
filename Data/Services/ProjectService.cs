using Data.Entities;
using Data.Repositories;

namespace Data.Services
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // CREATE
        public async Task<ProjectEntity> CreateAsync(ProjectEntity project)
        {
            return await _projectRepository.CreateAsync(project);
        }

        // READ
        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<ProjectEntity?> GetByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        // UPDATE
        public async Task<ProjectEntity?> UpdateAsync(ProjectEntity updatedProject)
        {
            return await _projectRepository.UpdateAsync(updatedProject);
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            return await _projectRepository.DeleteAsync(id);
        }
    }
}

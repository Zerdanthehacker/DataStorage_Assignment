using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Data.Repositories
{
    public class ProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<ProjectEntity> CreateAsync(ProjectEntity project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        } //funkar inte
        
        
        // READ
        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.Status)
                .Include(p => p.User)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<ProjectEntity?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.Status)
                .Include(p => p.User)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // UPDATE
        public async Task<ProjectEntity?> UpdateAsync(ProjectEntity updatedProject)
        {
            var existingProject = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == updatedProject.Id);
            if (existingProject != null)
            {
                existingProject.Title = updatedProject.Title;
                existingProject.Description = updatedProject.Description;
                existingProject.StartDate = updatedProject.StartDate;
                existingProject.EndDate = updatedProject.EndDate;
                existingProject.CustomerId = updatedProject.CustomerId;
                existingProject.StatusId = updatedProject.StatusId;
                existingProject.UserId = updatedProject.UserId;
                existingProject.ProductId = updatedProject.ProductId;

                await _context.SaveChangesAsync();
                return existingProject;
            }
            return null;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}


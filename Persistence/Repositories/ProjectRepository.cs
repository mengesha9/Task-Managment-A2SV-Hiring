using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entites;

namespace Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public readonly TaskManagmentDbContext _dbContext;
        public ProjectRepository(TaskManagmentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetProjectsByProjectOwner(string owner)
        {
            var result = _dbContext.Projects.Where(p => p.Owner == owner).ToList();
            return result;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.Contracts.Persistence
{
    public interface IProjectRepository:IGenericRepository<Project>
    {
        Task<List<Project>> GetProjectsByProjectOwner(string owner);
        
    }
}
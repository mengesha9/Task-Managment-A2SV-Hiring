using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        
        IProjectRepository ProjectRepository { get; }
        ITaskRepository TaskRepository { get; }
        IUserRepository UserRepository { get; }
    
        Task<int> Save();

    }
}
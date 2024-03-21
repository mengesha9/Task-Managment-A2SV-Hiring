using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Task = System.Threading.Tasks.Task;

namespace Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserById(string userId);
        Task<AppUser> GetUserByEmail(string email);
        Task<List<AppUser>> GetAllUsers();
        Task  UpdateUser(AppUser user);
        Task DeleteUser(AppUser user);
        
    }
}
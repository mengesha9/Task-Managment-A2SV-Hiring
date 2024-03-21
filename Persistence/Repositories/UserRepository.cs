using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TaskManagmentDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,TaskManagmentDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }

        public async System.Threading.Tasks.Task UpdateUser(AppUser user)
        {
            var result = await _userManager.UpdateAsync(user);

        }

        public async Task<List<AppUser>> GetAllUsers()
        {
            return await  _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return  await _userManager.FindByEmailAsync(email);
        }

        public async Task<AppUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async System.Threading.Tasks.Task DeleteUser(AppUser user)
        {
            await _userManager.DeleteAsync(user);
        }

    }
}
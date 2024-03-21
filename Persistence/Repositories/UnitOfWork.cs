using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TaskManagmentDbContext _context;

        private IUserRepository? _userRepository;
        private IProjectRepository? _projectRepository;
        private  ITaskRepository   _taskRepository;


        public UnitOfWork(TaskManagmentDbContext context)
        {
            _context = context;
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(_context);
                return _projectRepository;
            }
        }
      

        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(_context);
                return _taskRepository;
            }
        }
        

        

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_userManager, _signInManager, _context);
                return _userRepository;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
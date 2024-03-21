using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class TaskManagmentDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Domain.Entites.Task> Tasks { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        public TaskManagmentDbContext(DbContextOptions<TaskManagmentDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProject>()
                .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId);


            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Projects)
                .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Projects)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("UserProjects"));

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.Users)
                .HasForeignKey(t => t.UserId);

        }
    }
}
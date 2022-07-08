using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagementApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UserStory> UserStorys {get; set;}
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
    }
}

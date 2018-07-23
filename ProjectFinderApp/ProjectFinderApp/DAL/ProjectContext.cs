using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ProjectFinderApp.Models;

namespace ProjectFinderApp.DAL
{
    public class ProjectContext : DbContext
    {
        public  ProjectContext() : base("ProjectContext")
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
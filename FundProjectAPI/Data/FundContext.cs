﻿using FundProjectAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectAPI.Data
{
    public class FundContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Backer> Backers { get; set; }
        public DbSet<ProjectCreator> ProjectCreators { get; set; }
        public DbSet<BackerProject> BackerProjects { get; set; }
        public DbSet<RewardPackage> RewardPackage { get; set; }
        public FundContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Backer>().ToTable("Backer");
            modelBuilder.Entity<ProjectCreator>().ToTable("ProjectCreator");
            modelBuilder.Entity<BackerProject>().ToTable("BackerProject");
        }
    }
}

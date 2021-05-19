using Microsoft.EntityFrameworkCore;
using ProjetoSeplag.Domain.Updates.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSeplag.Infra.Data.Context
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=seplagdb;User Id=postgres;Password=docker;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<UpdateEntity> UpdateEntity { get; set; }



    }
}

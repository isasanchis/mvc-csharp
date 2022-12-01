using FiapSmartCity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FiapSmartCity.Repository.Context
{
    public class DataBaseContext : DbContext // context gerencia conexão com BD
    {
        // DbSet disponibiliza a entidade para podermos manipulá-la
        public DbSet<TipoProdutoEF> TipoProdutoEF { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
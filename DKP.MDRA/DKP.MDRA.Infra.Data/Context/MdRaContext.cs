using DKP.MDRA.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


namespace DKP.MDRA.Infra.Data.Context
{
    public class MdRaContext : DbContext
    {
        public MdRaContext()
            : base("defaultconnectionstring")
        {

        }

            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    if (!optionsBuilder.IsConfigured)
            //    {
            //        optionsBuilder.UseMySql("Server=localhost;User Id=mdra;Password=syswdsc;Database=mdra_db");
            //    }
            //}

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{ }

            //public DbSet<NotaServico> NotasServico { get; set; }
        }
}

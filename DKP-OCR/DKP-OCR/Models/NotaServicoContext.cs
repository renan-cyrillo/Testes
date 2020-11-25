using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DKP.OCR.Models
{
    public class NotaServicoContext : DbContext
    {
        public NotaServicoContext(DbContextOptions<NotaServicoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<NotaServico> NotasServico { get; set; }
    }
}


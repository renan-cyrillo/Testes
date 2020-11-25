using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKP.OCR.Models
{
    public static class InicializaDB
    {
        public static void Initialize(NotaServicoContext context)
        {
            context.Database.EnsureCreated();
            // Procura por livros
            if (context.NotasServico.Any())
            {
                return;   //O BD foi alimentado
            }
            var notasServico = new NotaServico[]
            {
              new NotaServico{Numero="12456", DataRecebidas= DateTime.Now,
DataEmissao= DateTime.Now, ValorTotal= "123"},
              new NotaServico{Numero="174258", DataRecebidas= DateTime.Now,
DataEmissao= DateTime.Now, ValorTotal= "999"}
            };
            foreach (NotaServico p in notasServico)
            {
                context.NotasServico.Add(p);
            }
            context.SaveChanges();
        }
    }
}

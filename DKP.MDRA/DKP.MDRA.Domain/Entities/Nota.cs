using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKP.MDRA.Domain.Entities
{
    class Nota
    {
        public int NotaId { get; set; }
        //public string ChaveAcesso { get; set; }
        public string Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataRecebidas { get; set; }
    }
}

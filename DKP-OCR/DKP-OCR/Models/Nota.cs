using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKP.OCR.Models
{
    public class Nota
{
    public int NotaId { get; set; }
    //public string ChaveAcesso { get; set; }
    public string Numero { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime DataRecebidas { get; set; }
    public string Tipo { get; set; }
    }
}

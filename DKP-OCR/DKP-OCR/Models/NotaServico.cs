using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DKP.OCR.Models
{
    [Table("NotaServico")]
    public class NotaServico : Nota
{

        [Display(Name = "ValorTotal")]
        [Column("ValorTotal")]
        public string ValorTotal { get; set; }

        [Display(Name = "PrestadorCnpj")]
        [Column("PrestadorCnpj")]
        public string PrestadorCnpj { get; set; }

        [Display(Name = "TomadorCnpj")]
        [Column("TomadorCnpj")]
        public string TomadorCnpj { get; set; }

        [Display(Name = "DiscriminacaoServicos")]
        [Column("DiscriminacaoServicos")]
        public string DiscriminacaoServicos { get; set; }

        [Display(Name = "Inss")]
        [Column("Inss")]
        public string Inss { get; set; }

        [Display(Name = "Irff")]
        [Column("Irff")]
        public string Irff { get; set; }

        [Display(Name = "Csll")]
        [Column("Csll")]
        public string Csll { get; set; }

        [Display(Name = "Cofins")]
        [Column("Cofins")]
        public string Cofins { get; set; }

        [Display(Name = "PisPasep")]
        [Column("PisPasep")]
        public string PisPasep { get; set; }

        [Display(Name = "ValorTotalDeducoes")]
        [Column("ValorTotalDeducoes")]
        public string ValorTotalDeducoes { get; set; }

        [Display(Name = "BaseCalculo")]
        [Column("BaseCalculo")]
        public string BaseCalculo { get; set; }

        [Display(Name = "Aliquota")]
        [Column("Aliquota")]
        public string Aliquota { get; set; }

        [Display(Name = "Iss")]
        [Column("Iss")]
        public string Iss { get; set; }

        [Display(Name = "Credito")]
        [Column("Credito")]
        public string Credito { get; set; }

        [Display(Name = "OutrasInformacoes")]
        [Column("OutrasInformacoes")]
        public string OutrasInformacoes { get; set; }
}
}

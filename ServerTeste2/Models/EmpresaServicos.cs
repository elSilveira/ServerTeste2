using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("EmpresaServicos")]
    public class EmpresaServicos
    {
        [Key]
        public int idEmpresaServico { get; set; }

        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public virtual Empresa empresa { get; set; }

        public int idServico { get; set; }
        [ForeignKey("idServico")]
        public virtual Servico servico { get; set; }

        public int tempoServico { get; set; }

        public double valorServico { get; set;}
        
    }
}

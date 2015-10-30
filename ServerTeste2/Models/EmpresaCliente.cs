using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("EmpresaCliente")]
    public class EmpresaCliente
    {
        [Key]
        public int idEmpresaCliente { get; set; }

        public int idEmpresa { get; set; }
        public virtual Empresa empresa { get; set; }

        public int idCliente { get; set; }
        public virtual Cliente cliente { get; set; }

        [Display(Name = "0-Cliente 1-funcionario 2-gerente 3-administrador", Description = "Tipo de cliente.")]
        public int tipoCliente { get; set; } // 0-Cliente 1-funcionario 2-gerente 3-administrador
        
    }
}

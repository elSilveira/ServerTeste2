using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public virtual Cliente cliente { get; set; }

        [MaxLength(200)]
        public string senhaUsuario { get; set; }

        [MaxLength(200)]
        public string roleUsuario { get; set; }
        
        public string tokenUsuario { get; set; }
    }
}

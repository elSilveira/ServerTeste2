using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        public int idServico { get; set; }

        [Required(ErrorMessage = "O Nome do serviço não pode ser em branco")]
        [MaxLength(150)]
        public string nomeServico { get; set; }


        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categoria categoria { get; set; }


    }
}

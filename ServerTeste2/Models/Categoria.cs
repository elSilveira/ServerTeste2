using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }

        [Required(ErrorMessage ="O Nome da categoria não pode ser em branco")]
        [MaxLength(150)]
        public string nomeCategoria { get; set; }
    }
}

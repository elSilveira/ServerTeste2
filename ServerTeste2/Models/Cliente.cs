using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }

        [Required(ErrorMessage ="Informe o nome.")]
        [Display(Name = "Nome cliente!", Description = "Informe o nome.")]
        [MaxLength(150)]
        public string nomeCliente { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome.")]
        [MaxLength(150)]
        public string sobrenomeCliente { get; set; }


        [Required(ErrorMessage = "Informe o telefone.")]
        [MaxLength(25)]
        public string telefoneCliente { get; set; }

        [Required(ErrorMessage = "Informe o email.")]
        [EmailAddress]
        [MaxLength(150)]
        [Index(IsUnique = true)]
        public string emailCliente { get; set; }

        [MaxLength(150)]
        public string cidadeCliente { get; set; }

        [MaxLength(150)]
        public string estadoCliente { get; set; }

        [MaxLength(150)]
        public string geoLatitudeCliente { get; set; }

        [MaxLength(150)]
        public string geoLongitudeCliente { get; set; }


    }
}

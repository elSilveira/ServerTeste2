using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("Empresas")]
    public class Empresa
    {

        [Key]
        public int idEmpresa { get; set; }

        [Required(ErrorMessage = "O Nome não pode ser em branco")]
        [MaxLength(150)]
        public string nomeEmpresa { get; set; }
        
        [MaxLength(100)]
        public string cidadeEmpresa { get; set; }
        
        [MaxLength(100)]
        public string estadoEmpresa { get; set; }
        
        [MaxLength(150)]
        public string ruaEmpresa { get; set; }

        [MaxLength(100)]
        public string bairroEmpresa { get; set; }

        [MaxLength(100)]
        public string geoLatitudeEmpresa { get; set; }

        [MaxLength(100)]
        public string geoLongitudeEmpresa { get; set; }

        [MaxLength(10)]
        public string cepEmpresa { get; set; }

        [Required(ErrorMessage = "O Numero não pode ser em branco")]
        public int numeroEmpresa { get; set; }

        public string imagemEmpresa { get; set; }
    }
}

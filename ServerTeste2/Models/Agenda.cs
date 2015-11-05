using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("Agenda")]
    public class Agenda
    {
        [Key]
        public int idAgenda { get; set; }

        public DateTime horarioAgenda { get; set; }

        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public virtual Empresa empresa { get; set; }

        public int idCliente { get; set; }
        [ForeignKey("idCliente")]
        public virtual Cliente cliente { get; set; }

        public int idFuncionario { get; set; }
        [ForeignKey("idCliente")]
        public virtual Cliente funcionario { get; set; }

        //Horário 0 = Inalterado, 1 = Disponível, 2 = Indisponível
        public int infoHorario { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("UsuarioServico")]
    class UsuarioServico
    {
        [Key]
        public int idUsuarioServico { get; set; }

        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categoria categoria { get; set; }

        public int idUsuario { get; set; }
        [ForeignKey("idServico")]
        public virtual Usuario usuario{ get; set; }

        public int idServico { get; set; }
        [ForeignKey("idServico")]
        public virtual Servico servico { get; set; }

        public int click { get; set; }

        /* O banco deve simplesmente armazenar os cliques para utilizar como referência na listagem
        deve ficar parecido com isto:
        Modelo1:
           ###usuario   : 420
           ###Categoria : 12
           ###Servico   : null    (Caso serviço seja Null a referência será apenas a categoria)
           ###Click     : 123 
        Modelo 2:
           ###usuario   : 420
           ###Categoria : 12
           ###Servico   : 3        (Agora a referência de cliques será ao servico / categoria)
           ###Click     : 98 

        Assim poderá ser verificado quantas vezes o usuário utilizou a categoria e quantas vezes selecionou o serviço.
        Este só será utilizado para listagem, o salão terá a referência própria do cliente para listagem de salões.
        =( é mais trabalhao e ta repetindo um pouco mas vai ser válido depois ^^
        */
        
    }

}

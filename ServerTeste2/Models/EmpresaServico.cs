﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerTeste2.Models
{
    [Table("EmpresaServico")]
    public class EmpresaServico
    {
        [Key]
        public int idEmpresaServico { get; set; }

        public int idEmpresa { get; set; }
        public virtual Empresa empresa { get; set; }

        public int idServico { get; set; }
        public virtual Servico servico { get; set; }

        public int tempoServico { get; set; }

        public double valorServico { get; set;}
    }
}

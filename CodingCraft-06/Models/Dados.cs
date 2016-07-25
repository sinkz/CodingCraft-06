using CodingCraft_06.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft_06.Models
{
    [Table("Dados")]
    public class Dados
    {
        [Key]
        public long Id { get; set; }
        public long IndicatorId { get; set; }
        public virtual Indicator Indicador { get; set; }
        public int Ano { get; set; }
        public float Valor { get; set; }
    }


}
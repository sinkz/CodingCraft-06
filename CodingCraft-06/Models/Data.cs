using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft_06.Models
{
    public class Data
    {
        [Key]
        public long DataId { get; set; }
        public long? RelatedIndicatorId { get; set; }

        public String Country { get; set; }
        public String Indicator { get; set; }
        public int Year { get; set; }
        public decimal? Value { get; set; }

        [ForeignKey("RelatedIndicatorId")]
        public virtual Indicator RelatedIndicator { get; set; }
    }
}
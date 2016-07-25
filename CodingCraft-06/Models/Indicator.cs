using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft_06.Models
{
    public class Indicator
    {
        [Key]
        public long IndicatorId { get; set; }

        [Required]
        public String Name { get; set; }
        [Required]
        public String Code { get; set; }

        public virtual ICollection<Data> RelatedData { get; set; }
    }
}
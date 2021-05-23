using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Order
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateIssued { get; set; }
        public double Total { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
    }
}

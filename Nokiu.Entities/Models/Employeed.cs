using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Employeed
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Employeed")]
        public virtual Person Person { get; set; }
    }
}

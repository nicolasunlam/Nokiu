using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Employee")]
        public virtual Person Person { get; set; }
    }
}

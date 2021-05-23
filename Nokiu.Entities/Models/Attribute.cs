using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            ServiceAttribute = new HashSet<ServiceAttribute>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Attribute")]
        public virtual Category Category { get; set; }
        [InverseProperty("Attribute")]
        public virtual ICollection<ServiceAttribute> ServiceAttribute { get; set; }
    }
}

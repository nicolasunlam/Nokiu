using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Service
    {
        public Service()
        {
            Product = new HashSet<Product>();
            ServiceAttribute = new HashSet<ServiceAttribute>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public int BusinessId { get; set; }

        [ForeignKey(nameof(BusinessId))]
        [InverseProperty("Service")]
        public virtual Business Business { get; set; }
        [InverseProperty("Service")]
        public virtual ICollection<Product> Product { get; set; }
        [InverseProperty("Service")]
        public virtual ICollection<ServiceAttribute> ServiceAttribute { get; set; }
    }
}

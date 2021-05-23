using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            AppointmentProduct = new HashSet<AppointmentProduct>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public double Price { get; set; }
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("Product")]
        public virtual Service Service { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<AppointmentProduct> AppointmentProduct { get; set; }
    }
}

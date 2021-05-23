using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Business
    {
        public Business()
        {
            Service = new HashSet<Service>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DateReserva { get; set; }
        [Required]
        [StringLength(50)]
        public string RazonSocial { get; set; }
        [Required]
        [StringLength(50)]
        public string Cuit { get; set; }
        public int CompanyId { get; set; }
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Business")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(CompanyId))]
        [InverseProperty("Business")]
        public virtual Company Company { get; set; }
        [InverseProperty("Business")]
        public virtual ICollection<Service> Service { get; set; }
    }
}

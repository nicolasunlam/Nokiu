using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Company
    {
        public Company()
        {
            Business = new HashSet<Business>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string DocNumber { get; set; }
        public int DocTypeId { get; set; }
        public int AddressId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Company")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(DocTypeId))]
        [InverseProperty("Company")]
        public virtual DocType DocType { get; set; }
        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Company")]
        public virtual Person Person { get; set; }
        [InverseProperty("Company")]
        public virtual ICollection<Business> Business { get; set; }
    }
}

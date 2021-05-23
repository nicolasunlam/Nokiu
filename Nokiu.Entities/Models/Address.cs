using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Address
    {
        public Address()
        {
            Business = new HashSet<Business>();
            Company = new HashSet<Company>();
            Person = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }
        [Required]
        [StringLength(50)]
        public string Locality { get; set; }
        [Required]
        [StringLength(50)]
        public string Town { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string PostCode { get; set; }
        [StringLength(50)]
        public string Latitude { get; set; }
        [StringLength(50)]
        public string Longitude { get; set; }

        [InverseProperty("Address")]
        public virtual ICollection<Business> Business { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Company> Company { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Person> Person { get; set; }
    }
}

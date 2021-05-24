using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Person
    {
        public Person()
        {
            Company = new HashSet<Company>();
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
            Owner = new HashSet<Owner>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        [Display(Name="Nombre")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }
        [StringLength(30)]
        public string DocNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateLogin { get; set; }
        [StringLength(250)]
        public string Photo { get; set; }
        [Display(Name = "Dirección")]
        public int? AddressId { get; set; }
        [Display(Name = "DNI")]
        public int? DocTypeId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Person")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(DocTypeId))]
        [InverseProperty("Person")]
        public virtual DocType DocType { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Person")]
        public virtual Role Role { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Company> Company { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Customer> Customer { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Employee> Employee { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Owner> Owner { get; set; }
    }
}

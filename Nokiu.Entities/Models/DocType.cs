using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class DocType
    {
        public DocType()
        {
            Company = new HashSet<Company>();
            Person = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [InverseProperty("DocType")]
        public virtual ICollection<Company> Company { get; set; }
        [InverseProperty("DocType")]
        public virtual ICollection<Person> Person { get; set; }
    }
}

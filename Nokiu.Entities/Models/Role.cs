﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            Person = new HashSet<Person>();
            RolePermission = new HashSet<RolePermission>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Person> Person { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}

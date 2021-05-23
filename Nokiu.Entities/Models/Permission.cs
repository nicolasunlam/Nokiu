using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Description { get; set; }
        public int ModuleId { get; set; }

        [InverseProperty("Permission")]
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    [Table("Role_Permission")]
    public partial class RolePermission
    {
        [Key]
        public int RoleId { get; set; }
        [Key]
        public int PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty("RolePermission")]
        public virtual Permission Permission { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RolePermission")]
        public virtual Role Role { get; set; }
    }
}

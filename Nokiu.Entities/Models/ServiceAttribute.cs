using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    [Table("Service_Attribute")]
    public partial class ServiceAttribute
    {
        [Key]
        public int ServiceId { get; set; }
        [Key]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        [InverseProperty("ServiceAttribute")]
        public virtual Attribute Attribute { get; set; }
        [ForeignKey(nameof(ServiceId))]
        [InverseProperty("ServiceAttribute")]
        public virtual Service Service { get; set; }
    }
}

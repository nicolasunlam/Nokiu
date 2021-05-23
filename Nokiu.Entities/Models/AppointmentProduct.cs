using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    [Table("Appointment_Product")]
    public partial class AppointmentProduct
    {
        [Key]
        public int AppointmentId { get; set; }
        [Key]
        public int ProductId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        [InverseProperty("AppointmentProduct")]
        public virtual Appointment Appointment { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("AppointmentProduct")]
        public virtual Product Product { get; set; }
    }
}

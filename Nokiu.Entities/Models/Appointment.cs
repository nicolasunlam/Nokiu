using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentProduct = new HashSet<AppointmentProduct>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int OrderId { get; set; }

        [InverseProperty("Appointment")]
        public virtual ICollection<AppointmentProduct> AppointmentProduct { get; set; }
    }
}

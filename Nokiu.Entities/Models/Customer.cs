﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nokiu.Entities.Models
{
    public partial class Customer
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Customer")]
        public virtual Person Person { get; set; }
    }
}

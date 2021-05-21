using System;
using System.Collections.Generic;

namespace Nokiu.Entities.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? DateLogin { get; set; }
        public DateTime? DateRegister { get; set; }
        public int Rol { get; set; }
    }
}

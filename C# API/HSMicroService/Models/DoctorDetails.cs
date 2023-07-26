using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DoctorDetails
    {
        [Key]

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string Role { get; set; } = string.Empty;
        public byte[]? Password { get; set; }
        public byte[]? HashKey { get; set; }
        public string Experience { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Specialization_name { get; set; } = string.Empty;
    }
}

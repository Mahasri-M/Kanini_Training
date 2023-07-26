﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateTime? Slot { get; set; }
        public string? Problem { get; set; }

    }
}

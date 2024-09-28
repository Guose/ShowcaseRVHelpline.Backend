﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class EmployeeService
    {
        public int? ServiceId { get; set; }
        public int? EmployeeId { get; set; }

        [InverseProperty("EmployeeServices")]
        public Employee? Employee { get; set; }

        [InverseProperty("EmployeeServices")]
        public ServiceClass? Service { get; set; }
    }
}

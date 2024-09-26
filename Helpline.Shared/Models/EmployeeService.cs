using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class EmployeeService
    {
        [Key, Column(Order = 0)]
        public int? ServiceId { get; set; }

        [Key, Column(Order = 1)]
        public int? EmployeeId { get; set; }

        [InverseProperty("EmployeeServices")]
        public Employee? Employee { get; set; }

        [InverseProperty("EmployeeServices")]
        public ServiceClass? Service { get; set; }
    }
}

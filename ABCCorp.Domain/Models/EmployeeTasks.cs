using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Domain.Models
{
    public class EmployeeTasks
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TaskId { get; set; }
    }
}

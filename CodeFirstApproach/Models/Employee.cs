using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
    }
}
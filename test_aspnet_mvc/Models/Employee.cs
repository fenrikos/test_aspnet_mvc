using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace test_aspnet_mvc.Domain.Entities
{
    
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Emp_id { get; set; }

        public int Job_id { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public double Salary { get; set; }
    }
}

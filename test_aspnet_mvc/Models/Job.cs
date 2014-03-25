using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace test_aspnet_mvc.Domain.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public int Job_id { get; set; }

        public string Job_nm { get; set; }
    }
}

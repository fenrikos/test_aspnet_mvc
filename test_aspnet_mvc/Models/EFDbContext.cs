using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using test_aspnet_mvc.Domain.Entities;

namespace test_aspnet_mvc.Models
{
    public class EFDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test_aspnet_mvc.Domain.Entities;

namespace test_aspnet_mvc.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Job> GetAllJobs();
        IEnumerable<Employee> GetEmployees(int job_id);
        Employee Get(int id);
        Employee Add(Employee item);
        void Remove(int id);
        bool Update(int emp_id, double salary);
    }
}
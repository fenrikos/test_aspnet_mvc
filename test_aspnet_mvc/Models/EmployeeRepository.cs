using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using test_aspnet_mvc.Domain.Entities;

namespace test_aspnet_mvc.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EFDbContext context = new EFDbContext();

        private static EmployeeRepository repo = new EmployeeRepository();
        public static IEmployeeRepository getRepository()
        {
            return repo;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return context.Jobs;
        }

        public IEnumerable<Employee> GetEmployees(int job_id)
        {
            var matches = context.Employees.Where(r => r.Job_id == job_id);
            return matches.Any() ? matches :null;
        }

        public Employee Get(int id)
        {
            return context.Employees.FirstOrDefault(w => w.Emp_id == id) ??
               context.Employees.FirstOrDefault() ??
                new Employee()
                {
                    Emp_id = 0,
                    Job_id = 0,
                    First_name = "Нету данных",
                    Last_name = "Нету данных",
                    Salary = 0
                };
        }

        public Employee Add(Employee item)
        {
            if (item.Emp_id == 0)
            {
                context.Employees.Add(item);
            }
            context.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            Employee item = Get(id);
            if (item != null)
            {
                context.Employees.Remove(item);
            }
            context.SaveChanges();
        }

        public bool Update(int emp_id, double salary)
        {
            try
            {
                context.Database.ExecuteSqlCommand("EXEC dbo.Update_Employee @Emp_id, @Salary", new SqlParameter("Emp_id", emp_id),
                    new SqlParameter("Salary", salary));
                Employee employee = context.Employees.FirstOrDefault(e => e.Emp_id == emp_id);
                context.Entry(employee).Reload();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
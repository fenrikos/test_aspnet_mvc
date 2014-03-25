using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using test_aspnet_mvc.Domain.Entities;
using test_aspnet_mvc.Models;

namespace test_aspnet_mvc.Controllers
{
    public class EmployeeController : ApiController
    {
        IEmployeeRepository repo = EmployeeRepository.getRepository();
        public EmployeeListViewModel GetEmployees(int job_id = 1, int page = 1, string sortBy = "Name", string kindOfSort = "asc")
        {
            int pageSize= Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            return new EmployeeListViewModel
            {
                Employees = (sortBy == "Name" && kindOfSort =="asc")? 
                repo.GetEmployees(job_id)
                .OrderBy(p => p.First_name+p.Last_name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize) : 
                (sortBy == "Name" && kindOfSort == "desc") ? 
                repo.GetEmployees(job_id)
                .OrderByDescending(p => p.First_name + p.Last_name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize) : (sortBy == "Salary" && kindOfSort == "asc") ? 
                repo.GetEmployees(job_id)
                .OrderBy(p => p.Salary)
                .Skip((page - 1) * pageSize)
                .Take(pageSize) : 
                repo.GetEmployees(job_id)
                .OrderByDescending(p => p.Salary)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = repo.GetEmployees(job_id).Count()
                },
                SortBy = sortBy,
                KindOfSort = kindOfSort
            };
        }

        //[HttpPost]
        //public Employee CreateEmployee(Employee item)
        //{
        //    return repo.Add(item);
        //}
        //public void DeleteEmployee(int id)
        //{
        //    repo.Remove(id);
        //}

        [HttpPut]
        public bool UpdateEmployee(Employee employee)
        {
            return repo.Update(employee.Emp_id, employee.Salary);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using test_aspnet_mvc.Domain.Entities;

namespace test_aspnet_mvc.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SortBy { get; set; }
        public string KindOfSort { get; set; }
        public bool IsSalaryEditable
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["IsSalaryEditable"]); }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using test_aspnet_mvc.Domain.Entities;
using test_aspnet_mvc.Models;

namespace test_aspnet_mvc.Controllers
{
    public class JobController : ApiController
    {
        IEmployeeRepository repo = EmployeeRepository.getRepository();
        public IEnumerable<Job> GetJobs()
        {
            return repo.GetAllJobs();
        }
    }
}

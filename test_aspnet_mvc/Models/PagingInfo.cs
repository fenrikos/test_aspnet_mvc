using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace test_aspnet_mvc.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]); }
        }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}
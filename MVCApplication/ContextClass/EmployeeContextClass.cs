using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApplication.ContextClass
{
    public class EmployeeContext : DbContext
    {
        
        public DbSet<Employee> emps { get; set; }

        public System.Data.Entity.DbSet<MVCApplication.Models.LoginPage> LoginPages { get; set; }
    }
}
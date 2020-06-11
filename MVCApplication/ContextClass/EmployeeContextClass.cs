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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<EmployeeContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
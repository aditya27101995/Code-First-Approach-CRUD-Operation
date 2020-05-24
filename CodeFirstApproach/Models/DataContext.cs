using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("sqlConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
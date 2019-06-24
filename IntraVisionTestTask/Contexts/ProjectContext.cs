using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntraVisionTestTask.Models;

namespace IntraVisionTestTask
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("DbConnection")
        { }

        public DbSet<CanOfDrink> CanOfDrinks { get; set; }
    }
}
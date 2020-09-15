using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace admTarea1.Models
{
    public class DataContext:DbContext 
    {
        public DataContext(): base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admTarea1.Models.Tarea1> Tarea1 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP_SEM3.Models
{
    public class MyDBContext:DbContext
    {

        public MyDBContext() : base("MyConnectionString") { }

        public System.Data.Entity.DbSet<ASP_SEM3.Models.LopHoc> LopHocs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Card_Resume_0._1.Models
{
    public class AAContext : DbContext
    {
        public DbSet<PersonInfo> PersonInfoes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Card_Resume_0._1.Views.Home
{
    public class PerInfo
    {
        public int ID { get; set; }
        public string Name1 { get; set; }
        public string Adres1 { get; set; }
        public long Tel1 { get; set; }
        public string E_Posta1 { get; set; }
    }

    public class ResumeDBContext : DbContext
    {
        public DbSet<PerInfo> PerInfos { get; set; }
    }

}
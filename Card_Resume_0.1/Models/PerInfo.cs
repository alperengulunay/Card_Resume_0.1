using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Card_Resume_0._1.Models
{
    public class PerInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name1 { get; set; }
        public string Adres1 { get; set; }
        public long Tel1 { get; set; }
        public string E_Posta1 { get; set; }
    }
}
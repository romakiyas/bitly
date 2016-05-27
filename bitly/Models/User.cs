using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bitly.Models
{
    [Table("bUsers")]   // на хостинге все базы заняты, разместил в имеющейся. дабы не конфликтовали имена
    public class User
    {
        [Key]
        public int id { get; set; }
        public string guid { get; set; }
        public DateTime firstVisit { get; set; }

        public virtual List<BitUrl> urls { get; set; }

        public User()
        {
            firstVisit = DateTime.Now;
            urls = new List<BitUrl>();
        }
    }
}
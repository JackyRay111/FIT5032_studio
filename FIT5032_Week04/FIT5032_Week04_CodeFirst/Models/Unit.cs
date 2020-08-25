using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_Week04_CodeFirst.Models
{
    public class Unit
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int StudengID { get; set; }

        public virtual Student Student { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_Week04_CodeFirst.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
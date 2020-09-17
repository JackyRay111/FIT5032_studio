using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FIT5032_Week06.Models
{
    public class SampleFormViewModels
    {
    }

    public class FormOneViewModel
    { 
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(3)]

        public string LastName { get; set; }
    }
}
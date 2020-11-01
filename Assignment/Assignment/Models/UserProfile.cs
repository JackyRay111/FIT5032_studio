namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class UserProfile
    {
        public string Id { get; set; }

        [StringLength(1024,ErrorMessage = "At least 2 Charactors long", MinimumLength = 2)]
        [AllowHtml]
        public string FirstName { get; set; }

        [StringLength(1024, ErrorMessage = "At least 2 Charactors long", MinimumLength = 2)]
        [AllowHtml]

        public string LastName { get; set; }

        [StringLength(256)]
        [EmailAddress(ErrorMessage = "Should be in a right Email Format")]
        
        public string Email { get; set; }

        
        [StringLength(256, ErrorMessage = "At least 8 Charactors long", MinimumLength = 8)]
        [RegularExpression("^[0-9]+$",ErrorMessage = "Should be all numbers")]
        public string PhoneNumber { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

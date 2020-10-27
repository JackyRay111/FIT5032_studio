namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RatingLog
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        [Column(TypeName = "date")]
        public DateTime RatingDate { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        public int ActivityPlaceId { get; set; }

        public virtual ActivityPlace ActivityPlace { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

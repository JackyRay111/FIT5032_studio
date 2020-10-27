namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class JoinLog
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public string AspNetUserId { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

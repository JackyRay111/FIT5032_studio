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
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime JoinDate { get; set; }

        [Key]
        [Column(Order = 1)]
        public string AspNetUserId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}

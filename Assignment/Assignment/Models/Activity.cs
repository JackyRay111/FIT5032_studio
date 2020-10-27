namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            JoinLogs = new HashSet<JoinLog>();

        }

        public int Id { get; set; }

        [Required]
        public string ActivityName { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime ActivityStartDate { get; set; }

        [Required]
        public string ActivityDescription { get; set; }

        public int ActivityTypeId { get; set; }

        public int ActivityPlaceId { get; set; }

        public int ActivityCategoryId { get; set; }

        public virtual ActivityPlace ActivityPlace { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public virtual ActivityCategory ActivityCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoinLog> JoinLogs { get; set; }

    }
}

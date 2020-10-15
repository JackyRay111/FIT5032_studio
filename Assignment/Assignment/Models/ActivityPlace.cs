namespace Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityPlace
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityPlace()
        {
            Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }

        [Required]
        public string ActivityPlaceName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ActivityPlaceLongitude { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ActivityPlaceLatitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}

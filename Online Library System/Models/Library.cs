namespace Online_Library_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Library")]
    public partial class Library
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Library()
        {
            BookLibraryLinks = new HashSet<BookLibraryLink>();
        }

        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(70)]
        public string Location { get; set; }

        [StringLength(20)]
        public string openHour { get; set; }

        [StringLength(20)]
        public string closeHour { get; set; }

        public byte[] picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookLibraryLink> BookLibraryLinks { get; set; }
    }
}

namespace Online_Library_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book()
        {
            BookLibraryLinks = new HashSet<BookLibraryLink>();
            BookRatings = new HashSet<BookRating>();
            BookUserLinks = new HashSet<BookUserLink>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public int? Price { get; set; }

        [StringLength(20)]
        public string isAvailable { get; set; }

        public int pagesCount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? releaseDate { get; set; }

        [StringLength(50)]
        public string genre { get; set; }

        [StringLength(20)]
        public string languages { get; set; }

        [Column(TypeName = "date")]
        public DateTime? importDate { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        public int? takes { get; set; }

        public byte[] picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookLibraryLink> BookLibraryLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookRating> BookRatings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookUserLink> BookUserLinks { get; set; }
    }
}

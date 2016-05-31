namespace Online_Library_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookLibraryLink")]
    public partial class BookLibraryLink
    {
        public int ID { get; set; }

        public int? BookID { get; set; }

        public int? LibraryID { get; set; }

        public virtual book book { get; set; }

        public virtual Library Library { get; set; }
    }
}

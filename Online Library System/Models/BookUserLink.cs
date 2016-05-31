namespace Online_Library_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookUserLink")]
    public partial class BookUserLink
    {
        public int ID { get; set; }

        public int? BookID { get; set; }

        public int? UserID { get; set; }

        public virtual book book { get; set; }

        public virtual User User { get; set; }
    }
}

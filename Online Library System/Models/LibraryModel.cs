namespace Online_Library_System.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryModel : DbContext
    {
        public LibraryModel()
            : base("name=LibraryModel4")
        {
        }

        public virtual DbSet<BookLibraryLink> BookLibraryLinks { get; set; }
        public virtual DbSet<BookRating> BookRatings { get; set; }
        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<BookUserLink> BookUserLinks { get; set; }
        public virtual DbSet<Library> Libraries { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

namespace bigschooll.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class bigschoolContext : DbContext
    {
        public bigschoolContext()
            : base("name=bigschoolContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Couser> Cousers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Cousers)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}

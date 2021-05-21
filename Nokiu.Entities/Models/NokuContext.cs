using Microsoft.EntityFrameworkCore;

namespace Nokiu.Entities.Models
{
    public partial class NokuContext : DbContext
    {
        public NokuContext()
        {
        }

        public NokuContext(DbContextOptions<NokuContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.Country).HasMaxLength(40);

                entity.Property(e => e.DateLogin)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateRegister)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

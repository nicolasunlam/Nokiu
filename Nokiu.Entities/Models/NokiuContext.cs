using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nokiu.Entities.Models
{
    public partial class NokiuContext : DbContext
    {
        public NokiuContext()
        {
        }

        public NokiuContext(DbContextOptions<NokiuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentProduct> AppointmentProduct { get; set; }
        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DocType> DocType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceAttribute> ServiceAttribute { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RIFDK0F\\SQLEXPRESS;Database=Nokiu;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentProduct>(entity =>
            {
                entity.HasKey(e => new { e.AppointmentId, e.ProductId })
                    .HasName("PK_APPOINTMENT_PRODUCT");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentProduct)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_PRODUCT_REFERENCE_PRODUCT");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AppointmentProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPOINTMENT_PRODUCT_REFERENCE_APPOINTMENT");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Attribute)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATTRIBUTE_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUSINESS_REFERENCE_ADDRESS");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUSINES_REFERENCE_COMPANY");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_CATEGORY_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANY_REFERENCE_ADDRESS");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANY_REFERENCE_DOC_TYPE");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COMPANY_REFERENCE_PERSON");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMER_REFERENCE_PERSON");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_REFERENCE_PERSON");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateIssued).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Owner)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OWNER_REFERENCE_PERSON");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.DocNumber)
                    .HasName("UQ__Person__DA35A0ABE27B86A2")
                    .IsUnique();

                entity.HasIndex(e => new { e.LastName, e.FirstName })
                    .HasName("IndexPersonName");

                entity.Property(e => e.DateLogin).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_PERSON_REFERENCE_ADDRESS");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.DocTypeId)
                    .HasConstraintName("FK_PERSON_REFERENCE_DOC_TYPE");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSON_REFERENCE_ROLE");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_REFERENCE_SERVICE");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId })
                    .HasName("PK_ROLE_PERMISSION");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_PERMISSION_REFERENCES_PERMISSION");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_PERMISSION_REFERENCES_ROLE");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_REFERENCE_BUSINESS");
            });

            modelBuilder.Entity<ServiceAttribute>(entity =>
            {
                entity.HasKey(e => new { e.ServiceId, e.AttributeId })
                    .HasName("PK_SERVICE_ATTRIBUTE");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ServiceAttribute)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_ATTRIBUTE_REFERENCE_ATTRIBUTE");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceAttribute)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_ATTRIBUTE_REFERENCE_SERVICE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

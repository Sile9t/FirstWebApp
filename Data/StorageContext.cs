using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.Data
{
    public class StorageContext : DbContext
    {
        private readonly string connection = @"Server=DESKTOP-U893DOI;Database=lessonDatabase;" +
            "TrustServerCertificate=True;Trusted_Connection=True";
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connection).UseLazyLoadingProxies()
                .LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("product_pk");
                entity.ToTable("product");

                entity.Property(x => x.Id)
                      .HasColumnName("id");
                entity.Property(x => x.Name)
                      .HasColumnName("name")
                      .HasMaxLength(255);
                entity.Property(x => x.Desctiption)
                      .HasColumnName("description")
                      .HasMaxLength(255);
                entity.Property(x => x.GroupId)
                      .HasColumnName("group_id");
                entity.Property(x => x.Group)
                      .HasColumnName("group");
                entity.Property(x => x.Storages)
                      .HasColumnName("storages");

                entity.HasOne(x => x.Group)
                      .WithMany(x => x.Products)
                      .HasForeignKey(x => x.GroupId);
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("product_group_pk");
                entity.ToTable("product_group");

                entity.Property(x => x.Id)
                      .HasColumnName("id");
                entity.Property(x => x.Name)
                      .HasColumnName("name")
                      .HasMaxLength(255);
                entity.Property(x => x.Description)
                      .HasColumnName("description")
                      .HasMaxLength(255);
                entity.Property(x => x.Products)
                      .HasColumnName("products");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("storage_pk");
                entity.ToTable("storage");

                entity.HasOne(x => x.Product)
                      .WithMany(x => x.Storages)
                      .HasForeignKey(x => x.ProductId);
            });
        }
    }
}

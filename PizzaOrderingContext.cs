using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzasShopDuoTask
{
    public partial class PizzaOrderingContext : DbContext
    {
        public PizzaOrderingContext()
        {
        }

        public PizzaOrderingContext(DbContextOptions<PizzaOrderingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItemDetail> OrderItemDetails { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<UsersDetail> UsersDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=DESKTOP-DVF528M\\SQLSERVER2019G3;user id = sa;password=iln120;Initial catalog = PizzaOrdering;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.DeliveryCharge).HasColumnName("delivery_charge");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UsersId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("users_id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__orders__users_id__2A4B4B5E");
            });

            modelBuilder.Entity<OrderItemDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("order_item_details");

                entity.Property(e => e.ItemNumber).HasColumnName("item_number");

                entity.Property(e => e.ToppingNumber).HasColumnName("topping_number");

                entity.HasOne(d => d.ItemNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ItemNumber)
                    .HasConstraintName("FK__order_ite__item___300424B4");

                entity.HasOne(d => d.ToppingNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ToppingNumber)
                    .HasConstraintName("FK__order_ite__toppi__30F848ED");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasKey(e => e.ItemNumber)
                    .HasName("PK__orderdet__77D8BCA17089E55A");

                entity.ToTable("orderdetails");

                entity.Property(e => e.ItemNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("item_number");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PizzaNumber).HasColumnName("pizza_number");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__orderdeta__order__2D27B809");

                entity.HasOne(d => d.PizzaNumberNavigation)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.PizzaNumber)
                    .HasConstraintName("FK__orderdeta__pizza__2E1BDC42");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.PizzaNumber)
                    .HasName("PK__pizza__9138DDC755CFDAFF");

                entity.ToTable("pizza");

                entity.Property(e => e.PizzaNumber).HasColumnName("pizza_number");

                entity.Property(e => e.PizzaName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pizza_name");

                entity.Property(e => e.PizzaType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pizza_type");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(e => e.ToppingNumber)
                    .HasName("PK__toppings__280F18AB5D4252B0");

                entity.ToTable("toppings");

                entity.Property(e => e.ToppingNumber).HasColumnName("topping_number");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ToppingName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("topping_name");
            });

            modelBuilder.Entity<UsersDetail>(entity =>
            {
                entity.HasKey(e => e.UserEmail)
                    .HasName("PK__UsersDet__B0FBA21309DCB52C");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

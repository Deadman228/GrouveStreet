using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GrouveStreet.Database.ContextDb
{
    public partial class AutoServiceContext : DbContext
    {
        public AutoServiceContext()
        {
        }

        public AutoServiceContext(DbContextOptions<AutoServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autopart> Autoparts { get; set; }
        public virtual DbSet<Categorypart> Categoryparts { get; set; }
        public virtual DbSet<Orderr> Orderrs { get; set; }
        public virtual DbSet<Orderservice> Orderservices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("server=localhost;port=5432;userid=user;database=AutoService;password=user");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autopart>(entity =>
            {
                entity.HasKey(e => e.Idpart)
                    .HasName("autoparts_pkey");

                entity.ToTable("autoparts");

                entity.Property(e => e.Idpart)
                    .HasColumnName("idpart")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .HasColumnType("char")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnType("char")
                    .HasColumnName("name");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Autoparts)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_c_a");
            });

            modelBuilder.Entity<Categorypart>(entity =>
            {
                entity.ToTable("categoryparts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("char")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Orderr>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("order_pkey");

                entity.ToTable("orderr");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Emploer).HasColumnName("emploer");

                entity.Property(e => e.Mark)
                    .HasColumnType("character varying")
                    .HasColumnName("mark");

                entity.Property(e => e.Number)
                    .HasColumnType("character varying")
                    .HasColumnName("number");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.EmploerNavigation)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.Emploer)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_o_e");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_o_s");
            });

            modelBuilder.Entity<Orderservice>(entity =>
            {
                entity.ToTable("orderservices");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Orderservices)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_services_order");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Orderservices)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_s_o");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Namerole)
                    .HasColumnType("character varying")
                    .HasColumnName("namerole");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Familia).HasColumnType("character varying");

                entity.Property(e => e.Login).HasColumnType("character varying");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.Password).HasColumnType("character varying");

                entity.Property(e => e.Patronomyc).HasColumnType("character varying");

                entity.Property(e => e.Phone).HasColumnType("character varying");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_u_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

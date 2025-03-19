using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JewerlyWorkshop.Models;

public partial class JewerlyStoreContext : DbContext
{
    public JewerlyStoreContext()
    {
    }

    public JewerlyStoreContext(DbContextOptions<JewerlyStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Jevel> Jevels { get; set; }

    public virtual DbSet<JevelType> JevelTypes { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=JewerlyStore;Username=postgres;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("clients_pk");

            entity.ToTable("clients");

            entity.Property(e => e.IdClient)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_client");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Jevel>(entity =>
        {
            entity.HasKey(e => e.IdJevel).HasName("jevels_pk");

            entity.ToTable("jevels");

            entity.Property(e => e.IdJevel)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_jevel");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.JevelName)
                .HasColumnType("character varying")
                .HasColumnName("jevel_name");
            entity.Property(e => e.JevelType)
                .HasColumnType("character varying")
                .HasColumnName("jevel_type");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.Jevels)
                .HasForeignKey(d => d.IdMaterial)
                .HasConstraintName("jevels_materials_fk");

            entity.HasOne(d => d.JevelTypeNavigation).WithMany(p => p.Jevels)
                .HasForeignKey(d => d.JevelType)
                .HasConstraintName("jevels_jevel_types_fk");
        });

        modelBuilder.Entity<JevelType>(entity =>
        {
            entity.HasKey(e => e.JevelType1).HasName("jevel_types_pk");

            entity.ToTable("jevel_types");

            entity.Property(e => e.JevelType1)
                .HasColumnType("character varying")
                .HasColumnName("jevel_type");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.IdMaster).HasName("masters_pk");

            entity.ToTable("masters");

            entity.Property(e => e.IdMaster)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_master");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.DismissialDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dismissial_date");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("materials_pk");

            entity.ToTable("materials");

            entity.Property(e => e.IdMaterial)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_material");
            entity.Property(e => e.GramPrice).HasColumnName("gram_price");
            entity.Property(e => e.MaterialName)
                .HasColumnType("character varying")
                .HasColumnName("material_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("orders_pk");

            entity.ToTable("orders");

            entity.Property(e => e.IdOrder)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_order");
            entity.Property(e => e.CompletionDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("completion_date");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdJevel).HasColumnName("id_jevel");
            entity.Property(e => e.IdMaster).HasColumnName("id_master");
            entity.Property(e => e.OrderDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("order_date");
            entity.Property(e => e.PaymentStatus)
                .HasColumnType("character varying")
                .HasColumnName("payment_status");
            entity.Property(e => e.ServiceName)
                .HasColumnType("character varying")
                .HasColumnName("service_name");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("orders_clients_fk");

            entity.HasOne(d => d.IdJevelNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdJevel)
                .HasConstraintName("orders_jevels_fk");

            entity.HasOne(d => d.IdMasterNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdMaster)
                .HasConstraintName("orders_masters_fk");

            entity.HasOne(d => d.ServiceNameNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServiceName)
                .HasConstraintName("orders_services_fk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("roles_pk");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("id_role");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceName).HasName("services_pk");

            entity.ToTable("services");

            entity.Property(e => e.ServiceName)
                .HasColumnType("character varying")
                .HasColumnName("service_name");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.IdUser)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_user");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("users_roles_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

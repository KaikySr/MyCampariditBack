using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Model;

public partial class MyCampariditContext : DbContext
{
    public MyCampariditContext()
    {
    }

    public MyCampariditContext(DbContextOptions<MyCampariditContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CargosXpermisso> CargosXpermissoes { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<Permisso> Permissoes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0018G\\SQLEXPRESS;Initial Catalog=MyCamparidit;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cargos__3214EC07C92C68A9");

            entity.ToTable("cargos");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.IdForum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cargos__IdForum__5441852A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cargos__IdUsuari__534D60F1");
        });

        modelBuilder.Entity<CargosXpermisso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CargosXp__3214EC072C9433C8");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.CargosXpermissos)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CargosXpe__IdCar__59063A47");

            entity.HasOne(d => d.IdPermissoesNavigation).WithMany(p => p.CargosXpermissos)
                .HasForeignKey(d => d.IdPermissoes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CargosXpe__IdPer__59FA5E80");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__forum__3214EC073225BFDF");

            entity.ToTable("forum");

            entity.Property(e => e.DataCriado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permisso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__permisso__3214EC07D4FA7A9D");

            entity.ToTable("permissoes");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post__3214EC078C2A59FD");

            entity.ToTable("post");

            entity.Property(e => e.Conteudo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DataCriado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Foto)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCriadorNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdCriador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post__DataCriado__4F7CD00D");

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdForum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post__IdForum__5070F446");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3214EC07BB35452A");

            entity.ToTable("usuario");

            entity.Property(e => e.DataNasc).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

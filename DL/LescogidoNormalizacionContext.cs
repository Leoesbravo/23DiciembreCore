using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class LescogidoNormalizacionContext : DbContext
{
    public LescogidoNormalizacionContext()
    {
    }

    public LescogidoNormalizacionContext(DbContextOptions<LescogidoNormalizacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<AutorLibro> AutorLibros { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Colonium> Colonia { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Subcategoria2> Subcategoria2s { get; set; }

    public virtual DbSet<Subcategorium> Subcategoria { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.104,1433; Database=LEscogidoNormalizacion; ;TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__DD33B031964EA8EB");

            entity.ToTable("Autor");

            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AutorLibro>(entity =>
        {
            entity.HasKey(e => e.IdAutorLibro).HasName("PK__AutorLib__77230428A8EF609C");

            entity.ToTable("AutorLibro");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.AutorLibros)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AutorLibr__IdAut__21B6055D");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.AutorLibros)
                .HasForeignKey(d => d.IdLibro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AutorLibr__IdLib__20C1E124");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__CATEGORI__ADC0E7197DC05043");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Colonium>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__Colonia__A1580F66B385FD6E");

            entity.Property(e => e.IdColonia).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Colonia__IdMunic__46E78A0C");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C76C08BE3B7");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK__Direccion__IdCol__4D94879B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Direccion__IdUsu__4CA06362");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC14E608A95");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK__Estado__IdPais__412EB0B6");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libro__3E0B49AD6B2AEA87");

            entity.ToTable("Libro");

            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__6100597877C21F4C");

            entity.ToTable("Municipio");

            entity.Property(e => e.IdMunicipio).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Municipio__IdEst__440B1D61");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__FC850A7B1C32D6BE");

            entity.Property(e => e.IdPais).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__PRODUCTO__7D8DC0F1F954C4B5");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.Idproducto).HasColumnName("IDPRODUCTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Idsubcategoria2).HasColumnName("IDSUBCATEGORIA2");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Stock).HasColumnName("STOCK");

            entity.HasOne(d => d.Idsubcategoria2Navigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idsubcategoria2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subcategoria2Producto");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CD1433B52");

            entity.ToTable("Rol");

            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subcategoria2>(entity =>
        {
            entity.HasKey(e => e.Idsubcategoria2).HasName("PK__SUBCATEG__A4CEA9D8E594BBDA");

            entity.ToTable("SUBCATEGORIA2");

            entity.Property(e => e.Idsubcategoria2).HasColumnName("IDSUBCATEGORIA2");
            entity.Property(e => e.Idsubcategoria).HasColumnName("IDSUBCATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdsubcategoriaNavigation).WithMany(p => p.Subcategoria2s)
                .HasForeignKey(d => d.Idsubcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubategoriaSubcategoria2");
        });

        modelBuilder.Entity<Subcategorium>(entity =>
        {
            entity.HasKey(e => e.Idsubcategoria).HasName("PK__SUBCATEG__361848F7864A2413");

            entity.ToTable("SUBCATEGORIA");

            entity.Property(e => e.Idsubcategoria).HasColumnName("IDSUBCATEGORIA");
            entity.Property(e => e.Idcategoria).HasColumnName("IDCATEGORIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Subcategoria)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoriaSubcategoria");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9750C8375A");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).HasColumnName("IMAGEN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

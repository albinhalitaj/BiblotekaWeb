using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BiblotekaWeb.Areas.admin.Models
{
    public partial class BiblotekaWebContext : DbContext
    {
        public BiblotekaWebContext()
        {
        }

        public BiblotekaWebContext(DbContextOptions<BiblotekaWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aktiviteti> Aktivitetis { get; set; }
        public virtual DbSet<Gjoba> Gjobas { get; set; }
        public virtual DbSet<Gjuha> Gjuhas { get; set; }
        public virtual DbSet<Huazimi> Huazimis { get; set; }
        public virtual DbSet<Kategorium> Kategoria { get; set; }
        public virtual DbSet<Klienti> Klientis { get; set; }
        public virtual DbSet<Libri> Libris { get; set; }
        public virtual DbSet<Perdoruesi> Perdoruesis { get; set; }
        public virtual DbSet<Roli> Rolis { get; set; }
        public virtual DbSet<Stafi> Stafis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BiblotekaWeb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aktiviteti>(entity =>
            {
                entity.ToTable("Aktiviteti");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.KlientiId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("KlientiID");

                entity.Property(e => e.LibriId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LibriID");

                entity.Property(e => e.Tipi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Klienti)
                    .WithMany(p => p.Aktivitetis)
                    .HasForeignKey(d => d.KlientiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aktiviteti_Klienti");

                entity.HasOne(d => d.Libri)
                    .WithMany(p => p.Aktivitetis)
                    .HasForeignKey(d => d.LibriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aktiviteti_Libri");

                entity.HasOne(d => d.Punetori)
                    .WithMany(p => p.Aktivitetis)
                    .HasForeignKey(d => d.PunetoriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aktiviteti_Stafi");
            });

            modelBuilder.Entity<Gjoba>(entity =>
            {
                entity.ToTable("Gjoba");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.InsertBy).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.KlientiId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LibriId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Shuma).HasColumnType("money");

                entity.Property(e => e.ShumaPranuar).HasColumnType("money");

                entity.HasOne(d => d.Klienti)
                    .WithMany(p => p.Gjobas)
                    .HasForeignKey(d => d.KlientiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gjoba_Klienti");

                entity.HasOne(d => d.Libri)
                    .WithMany(p => p.Gjobas)
                    .HasForeignKey(d => d.LibriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gjoba_Libri");
            });

            modelBuilder.Entity<Gjuha>(entity =>
            {
                entity.ToTable("Gjuha");

                entity.Property(e => e.GjuhaId).HasColumnName("GjuhaID");

                entity.Property(e => e.Emertimi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Pershkrimi).HasMaxLength(50);
            });

            modelBuilder.Entity<Huazimi>(entity =>
            {
                entity.ToTable("Huazimi");

                entity.Property(e => e.HuazimiId).HasColumnName("HuazimiID");

                entity.Property(e => e.DataHuazimi).HasColumnType("date");

                entity.Property(e => e.DataKthimit).HasColumnType("date");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.KlientiId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("KlientiID");

                entity.Property(e => e.LibriId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LibriID");

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Pershkrimi).HasMaxLength(50);


                entity.HasOne(d => d.Klienti)
                    .WithMany(p => p.Huazimis)
                    .HasForeignKey(d => d.KlientiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Huazimi_Klienti");

                entity.HasOne(d => d.Libri)
                    .WithMany(p => p.Huazimis)
                    .HasForeignKey(d => d.LibriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Huazimi_Libri");

            });

            modelBuilder.Entity<Kategorium>(entity =>
            {
                entity.HasKey(e => e.KategoriaId);

                entity.Property(e => e.KategoriaId).HasColumnName("KategoriaID");

                entity.Property(e => e.Emertimi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Pershkrimi).HasMaxLength(50);
            });

            modelBuilder.Entity<Klienti>(entity =>
            {
                entity.ToTable("Klienti");

                entity.Property(e => e.KlientiId)
                    .HasMaxLength(50)
                    .HasColumnName("KlientiID");

                entity.Property(e => e.Adresa).HasMaxLength(100);

                entity.Property(e => e.Datalindjes).HasColumnType("date");

                entity.Property(e => e.Emaili).HasMaxLength(50);

                entity.Property(e => e.Emri)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gjinia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InsertBy).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.KodiPostal).HasMaxLength(50);

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Mbiemri)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NrKontaktues)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NrPersonal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qyteti).HasMaxLength(50);

                entity.Property(e => e.Shteti).HasMaxLength(50);
            });

            modelBuilder.Entity<Libri>(entity =>
            {
                entity.ToTable("Libri");

                entity.Property(e => e.LibriId)
                    .HasMaxLength(50)
                    .HasColumnName("LibriID");

                entity.Property(e => e.Autori)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Botuesi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Editioni)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GjuhaId).HasColumnName("GjuhaID");

                entity.Property(e => e.ImageName).HasMaxLength(200);

                entity.Property(e => e.InsertBy).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.KategoriaId).HasColumnName("KategoriaID");

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Titulli)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Gjuha)
                    .WithMany(p => p.Libris)
                    .HasForeignKey(d => d.GjuhaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libri_Gjuha");

                entity.HasOne(d => d.Kategoria)
                    .WithMany(p => p.Libris)
                    .HasForeignKey(d => d.KategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libri_Kategoria");
            });

            modelBuilder.Entity<Perdoruesi>(entity =>
            {
                entity.ToTable("Perdoruesi");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Roli)
                    .WithMany(p => p.Perdoruesis)
                    .HasForeignKey(d => d.RoliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perdoruesi_Roli");

                entity.HasOne(d => d.Stafi)
                    .WithMany(p => p.Perdoruesis)
                    .HasForeignKey(d => d.StafiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perdoruesi_Stafi");
            });

            modelBuilder.Entity<Roli>(entity =>
            {
                entity.ToTable("Roli");

                entity.Property(e => e.EmriRolit)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pershkrimi)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Stafi>(entity =>
            {
                entity.ToTable("Stafi");

                entity.Property(e => e.Adresa).HasMaxLength(50);

                entity.Property(e => e.Datalindjes).HasColumnType("date");

                entity.Property(e => e.Emaili)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Emri)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gjinia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.InsertBy).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Lub).HasColumnName("LUB");

                entity.Property(e => e.Lud)
                    .HasColumnType("date")
                    .HasColumnName("LUD");

                entity.Property(e => e.Lun).HasColumnName("LUN");

                entity.Property(e => e.Mbiemri)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefoni).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

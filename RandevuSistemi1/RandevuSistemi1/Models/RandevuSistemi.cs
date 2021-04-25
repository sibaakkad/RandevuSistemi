namespace RandevuSistemi1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RandevuSistemi : DbContext
    {
        public RandevuSistemi()
            : base("name=RandevuSistemi1")
        {
        }

        public virtual DbSet<Adminler> Adminlers { get; set; }
        public virtual DbSet<Akademisyenler> Akademisyenlers { get; set; }
        public virtual DbSet<Bolumler> Bolumlers { get; set; }
        public virtual DbSet<Fakulteler> Fakultelers { get; set; }
        public virtual DbSet<GecmisRandevular> GecmisRandevulars { get; set; }
        public virtual DbSet<Kullaniciler> Kullanicilers { get; set; }
        public virtual DbSet<Müsaitlikler> Müsaitlikler { get; set; }
        public virtual DbSet<Ogrenciler> Ogrencilers { get; set; }
        public virtual DbSet<Randevu> Randevus { get; set; }
        public virtual DbSet<Saatler> Saatlers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminler>()
                .Property(e => e.KullaniciAdi)
                .IsUnicode(false);

            modelBuilder.Entity<Adminler>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<Adminler>()
                .HasMany(e => e.Kullanicilers)
                .WithOptional(e => e.Adminler)
                .HasForeignKey(e => e.adminGirisID);

            modelBuilder.Entity<Akademisyenler>()
                .Property(e => e.Eposta)
                .IsUnicode(false);

            modelBuilder.Entity<Akademisyenler>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Akademisyenler>()
                .Property(e => e.Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<Akademisyenler>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<Akademisyenler>()
                .HasMany(e => e.Kullanicilers)
                .WithOptional(e => e.Akademisyenler)
                .HasForeignKey(e => e.akmGirisID);

            modelBuilder.Entity<Bolumler>()
                .Property(e => e.BolumAd)
                .IsUnicode(false);

            modelBuilder.Entity<Fakulteler>()
                .Property(e => e.FakulteAd)
                .IsUnicode(false);

            modelBuilder.Entity<Fakulteler>()
                .HasMany(e => e.Ogrencilers)
                .WithRequired(e => e.Fakulteler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GecmisRandevular>()
                .Property(e => e.Konu)
                .IsUnicode(false);

            modelBuilder.Entity<Kullaniciler>()
                .Property(e => e.Eposta)
                .IsUnicode(false);

            modelBuilder.Entity<Kullaniciler>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<Kullaniciler>()
                .Property(e => e.KullaniciRole)
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenciler>()
                .Property(e => e.OgrNo)
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenciler>()
                .Property(e => e.EPosta)
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenciler>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenciler>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenciler>()
                .Property(e => e.Soyad)
                .IsUnicode(false);

            modelBuilder.Entity<Ogrenciler>()
                .HasMany(e => e.Kullanicilers)
                .WithOptional(e => e.Ogrenciler)
                .HasForeignKey(e => e.ogrenciGirisID);

            modelBuilder.Entity<Randevu>()
                .Property(e => e.Konu)
                .IsUnicode(false);
        }
    }
}

namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Akademisyenler")]
    public partial class Akademisyenler
    {
        public Akademisyenler()
        {
            Kullanicilers = new HashSet<Kullaniciler>();
            GecmisRandevulars = new HashSet<GecmisRandevular>();
            Müsaitlikler = new HashSet<Müsaitlikler>();
            Randevus = new HashSet<Randevu>();
        }

        [Key]
        public int AkmId { get; set; }

        [StringLength(60)]
        public string Eposta { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        public int? FakulteId { get; set; }

        public int? BolumId { get; set; }

        [StringLength(50)]
        public string Parola { get; set; }

        public virtual ICollection<Kullaniciler> Kullanicilers { get; set; }

        public virtual Bolumler Bolumler { get; set; }

        public virtual Fakulteler Fakulteler { get; set; }

        public virtual ICollection<GecmisRandevular> GecmisRandevulars { get; set; }

        public virtual ICollection<Müsaitlikler> Müsaitlikler { get; set; }

        public virtual ICollection<Randevu> Randevus { get; set; }
    }
}

namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ogrenciler")]
    public partial class Ogrenciler
    {
        public Ogrenciler()
        {
            GecmisRandevulars = new HashSet<GecmisRandevular>();
            Kullanicilers = new HashSet<Kullaniciler>();
            Randevus = new HashSet<Randevu>();
        }

        [Key]
        public int OgrId { get; set; }

        [StringLength(15)]
        public string OgrNo { get; set; }

        [StringLength(60)]
        public string EPosta { get; set; }

        [StringLength(50)]
        public string Parola { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        public int FakulteId { get; set; }

        public int? BolumId { get; set; }

        public virtual Bolumler Bolumler { get; set; }

        public virtual Fakulteler Fakulteler { get; set; }

        public virtual ICollection<GecmisRandevular> GecmisRandevulars { get; set; }

        public virtual ICollection<Kullaniciler> Kullanicilers { get; set; }

        public virtual ICollection<Randevu> Randevus { get; set; }
    }
}

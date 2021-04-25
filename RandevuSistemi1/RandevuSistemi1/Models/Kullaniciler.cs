namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullaniciler")]
    public partial class Kullaniciler
    {
        [Key]
        public int kullaniciId { get; set; }

        [Required]
        [StringLength(50)]
        public string Eposta { get; set; }

        [Required]
        [StringLength(50)]
        public string Parola { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciRole { get; set; }

        public int? adminGirisID { get; set; }

        public int? ogrenciGirisID { get; set; }

        public int? akmGirisID { get; set; }

        public virtual Adminler Adminler { get; set; }

        public virtual Akademisyenler Akademisyenler { get; set; }

        public virtual Ogrenciler Ogrenciler { get; set; }

    }
}

namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Randevu")]
    public partial class Randevu
    {
        public int RandevuId { get; set; }

        public int? AkmId { get; set; }

        public int? OgrId { get; set; }

        [StringLength(40)]
        public string Konu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public int? SaatId { get; set; }

        public bool? AktifMi { get; set; }

        public virtual Akademisyenler Akademisyenler { get; set; }

        public virtual Ogrenciler Ogrenciler { get; set; }

        public virtual Saatler Saatler { get; set; }
    }
}

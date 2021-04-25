namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GecmisRandevular")]
    public partial class GecmisRandevular
    {
        public int Id { get; set; }

        public int? AkmId { get; set; }

        public int? OgrId { get; set; }

        [StringLength(40)]
        public string Konu { get; set; }

        public DateTime? Tarih { get; set; }

        public TimeSpan? Saat { get; set; }

        public virtual Akademisyenler Akademisyenler { get; set; }

        public virtual Ogrenciler Ogrenciler { get; set; }
    }
}

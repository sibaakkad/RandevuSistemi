namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bolumler")]
    public partial class Bolumler
    {
        public Bolumler()
        {
            Akademisyenlers = new HashSet<Akademisyenler>();
            Ogrencilers = new HashSet<Ogrenciler>();
        }

        [Key]
        public int BolumId { get; set; }

        [StringLength(50)]
        public string BolumAd { get; set; }

        public int? FakulteId { get; set; }

        public virtual ICollection<Akademisyenler> Akademisyenlers { get; set; }

        public virtual Fakulteler Fakulteler { get; set; }

        public virtual ICollection<Ogrenciler> Ogrencilers { get; set; }
    }
}

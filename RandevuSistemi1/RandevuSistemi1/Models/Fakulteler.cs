namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fakulteler")]
    public partial class Fakulteler
    {
        public Fakulteler()
        {
            Akademisyenlers = new HashSet<Akademisyenler>();
            Bolumlers = new HashSet<Bolumler>();
            Ogrencilers = new HashSet<Ogrenciler>();
        }

        [Key]
        public int FakulteId { get; set; }

        [StringLength(50)]
        public string FakulteAd { get; set; }

        public virtual ICollection<Akademisyenler> Akademisyenlers { get; set; }

        public virtual ICollection<Bolumler> Bolumlers { get; set; }

        public virtual ICollection<Ogrenciler> Ogrencilers { get; set; }
    }
}

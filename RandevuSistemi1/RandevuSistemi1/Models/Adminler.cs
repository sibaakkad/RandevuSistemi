namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adminler")]
    public partial class Adminler
    {
        public Adminler()
        {
            Kullanicilers = new HashSet<Kullaniciler>();
        }

        [Key]
        public int adminID { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string Parola { get; set; }

        public virtual ICollection<Kullaniciler> Kullanicilers { get; set; }
    }
}

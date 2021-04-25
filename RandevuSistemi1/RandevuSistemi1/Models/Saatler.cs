namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Saatler")]
    public partial class Saatler
    {
        public Saatler()
        {
            Müsaitlikler = new HashSet<Müsaitlikler>();
            Randevus = new HashSet<Randevu>();
        }

        [Key]
        public int SaatId { get; set; }

        public TimeSpan? Saat { get; set; }

        public virtual ICollection<Müsaitlikler> Müsaitlikler { get; set; }

        public virtual ICollection<Randevu> Randevus { get; set; }
    }
}

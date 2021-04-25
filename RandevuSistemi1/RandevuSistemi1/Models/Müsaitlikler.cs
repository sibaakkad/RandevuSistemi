namespace RandevuSistemi1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Müsaitlikler
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public int? SaatId { get; set; }

        public int? AkmId { get; set; }

        public virtual Akademisyenler Akademisyenler { get; set; }

        public virtual Saatler Saatler { get; set; }
    }
}

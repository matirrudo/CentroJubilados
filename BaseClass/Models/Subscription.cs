namespace BaseClass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscription")]
    public partial class Subscription
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Month { get; set; }

        public int Year { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public int AffiliateId { get; set; }

        public virtual Affiliate Affiliate { get; set; }
    }
}

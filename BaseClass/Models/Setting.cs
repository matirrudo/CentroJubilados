namespace BaseClass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Setting")]
    public partial class Setting
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? SubscriptionPrice { get; set; }

        [StringLength(10)]
        public string SubscriptionMonth { get; set; }

        public int? SubscriptionYear { get; set; }

        public virtual User User { get; set; }
    }
}

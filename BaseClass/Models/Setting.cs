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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public decimal? ContributionPrice { get; set; }

        [StringLength(10)]
        public string MonthContribution { get; set; }

        public int? YearContribution { get; set; }

        public virtual User User { get; set; }
    }
}

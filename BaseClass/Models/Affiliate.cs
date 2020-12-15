namespace BaseClass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Affiliate")]
    public partial class Affiliate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Firstaname { get; set; }

        [Required]
        [StringLength(25)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(10)]
        public string DNI { get; set; }

        [StringLength(10)]
        public string BenefitNumber { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? DateOfReincorporation { get; set; }

        public bool Active { get; set; }

        public int TypeOfAffiliateId { get; set; }

        public int? WorkshopId { get; set; }

        public virtual TypeOfAffiliate TypeOfAffiliate { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}

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
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string Firstaname { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string Lastname { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DNI { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BenefitNumber { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime Birthdate { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Address { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime RegistrationDate { get; set; }

        public DateTime? DateOfReincorporation { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool Active { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeOfAffiliateId { get; set; }

        public int? WorkshopId { get; set; }

        public virtual TypeOfAffiliate TypeOfAffiliate { get; set; }

        public virtual Workshop Workshop { get; set; }
    }
}

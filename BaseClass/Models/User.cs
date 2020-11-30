namespace BaseClass.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RolId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(25)]
        public string Firstname { get; set; }

        [StringLength(25)]
        public string Lastname { get; set; }

        public virtual Rol Rol { get; set; }
    }
}

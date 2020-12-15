namespace BaseClass.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CentroJubiladoDbContext : DbContext
    {
        public CentroJubiladoDbContext()
            : base("name=CentroJubiladoDbContext")
        {
        }

        public virtual DbSet<Affiliate> Affiliate { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TypeOfAffiliate> TypeOfAffiliate { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Affiliate>()
                .Property(e => e.Firstaname)
                .IsUnicode(false);

            modelBuilder.Entity<Affiliate>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Affiliate>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<Affiliate>()
                .Property(e => e.BenefitNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Affiliate>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Affiliate>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeOfAffiliate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfAffiliate>()
                .HasMany(e => e.Affiliate)
                .WithRequired(e => e.TypeOfAffiliate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Workshop>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Workshop>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Setting>()
                .Property(e => e.ContributionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Setting>()
                .Property(e => e.MonthContribution)
                .IsFixedLength();
        }
    }
}

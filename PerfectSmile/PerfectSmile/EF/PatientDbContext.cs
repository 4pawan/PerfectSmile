using System.Data.Entity;

namespace PerfectSmile.EF
{
    public class PatientDbContext : DbContext
    {

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientHistory> PatientHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }



        public PatientDbContext()
            : base("perfectsmileEntities")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Patient>()
               .HasMany(e => e.PatientHistories)
               .WithRequired(e => e.Patient)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<PatientHistory>()
                .Property(e => e.PaymentDone)
                .HasPrecision(53, 0);

            modelBuilder.Entity<PatientHistory>()
                .Property(e => e.Balance)
                .HasPrecision(53, 0);


            var initializer = new PatientDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}

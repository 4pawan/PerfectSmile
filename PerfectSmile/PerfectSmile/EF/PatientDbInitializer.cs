using System.Data.Entity;
using SQLite.CodeFirst;

namespace PerfectSmile.EF
{
    public class PatientDbInitializer : SqliteCreateDatabaseIfNotExists<PatientDbContext>
    {
        public PatientDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {
        }

        protected override void Seed(PatientDbContext context)
        {
            context.Set<User>().Add(new User
            {
                Name = "pk",
                Password = "pk"
            });

            context.Set<User>().Add(new User
            {
                Name = "sy",
                Password = "sy"
            });

        }



    }
}
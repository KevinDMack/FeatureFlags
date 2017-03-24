using FeatureFlags.Data.Interfaces;
using FeatureFlags.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeatureFlags.Data
{
    public class DataContext : DbContext
    {
        #region Properties

        public DbSet<FeatureFlag> FeatureFlag { get; set; }
        public DbSet<FeatureRole> FeatureRole { get; set; }
        public DbSet<FeatureRoleUser> FeatureRoleUser { get; set; }
        public DbSet<FeatureStateRole> FeatureStateRole { get; set;}
        public DbSet<FeatureState> FeatureState { get; set; }
        public DbSet<FeatureFeedback> FeatureFeedback { get; set; }

        #endregion

        public DataContext()
            : base("DefaultConnection")
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeatureFlag>();
            modelBuilder.Entity<FeatureRole>();
            modelBuilder.Entity<FeatureRoleUser>();
            modelBuilder.Entity<FeatureStateRole>();
            modelBuilder.Entity<FeatureState>();
            modelBuilder.Entity<FeatureFeedback>();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var auditable = ChangeTracker.Entries<IEntity>().ToList();

            if (!auditable.Any()) return base.SaveChanges();

            foreach (var dbEntry in auditable)
            {
                switch (dbEntry.State)
                {
                    case System.Data.Entity.EntityState.Added:
                        if (dbEntry.Entity.Key == Guid.Empty)
                        {
                            dbEntry.Entity.Key = Guid.NewGuid();
                        }
                        if (dbEntry.Entity.EffectiveDate == DateTime.MinValue)
                        {
                            dbEntry.Entity.EffectiveDate = DateTime.Now;
                        }
                        break;
                }
            }



            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}

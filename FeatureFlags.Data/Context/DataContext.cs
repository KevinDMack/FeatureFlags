﻿using FeatureFlags.Data.Interfaces;
using FeatureFlags.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyIoC;

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
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var auditable = ChangeTracker.Entries<IEntity>().ToList();

            if (!auditable.Any()) return base.SaveChanges();

            foreach (var dbEntry in auditable)
            {
                //var userIdentityProvider = TinyIoCContainer.Current.Resolve<IUserIdentityProvider>();

                switch (dbEntry.State)
                {
                    case System.Data.Entity.EntityState.Added:
                        if (dbEntry.Entity.Key == Guid.Empty)
                        {
                            dbEntry.Entity.Key = Guid.NewGuid();
                        }
                        //dbEntry.Entity.DateAdded = DateTime.Now;
                        //dbEntry.Entity.AddedBy = userIdentityProvider.CurrentUserName;
                        if (dbEntry.Entity.EffectiveDate == DateTime.MinValue)
                        {
                            dbEntry.Entity.EffectiveDate = DateTime.Now;
                        }
                        break;
                    case System.Data.Entity.EntityState.Modified:
                        //if (String.IsNullOrEmpty(dbEntry.Entity.AddedBy))
                        //{
                        //    dbEntry.Entity.DateAdded = DateTime.Now;
                        //    dbEntry.Entity.AddedBy = userIdentityProvider.CurrentUserName;
                        //}

                        //dbEntry.Entity.DateModified = DateTime.Now;
                        //dbEntry.Entity.ModifiedBy = userIdentityProvider.CurrentUserName;
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
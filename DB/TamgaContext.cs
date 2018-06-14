using DB.Model;
using System;
using System.Data.Entity;

namespace DB
{
    public class TamgaContext: DbContext
    {
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TamgaContext>(new DropCreateDatabaseIfModelChanges<TamgaContext>());
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}

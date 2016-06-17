using EnmerCore.DataObjects;

namespace EnmerCore
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnmerDbContext : DbContext
    {
        public EnmerDbContext()
            : base("name=EnmerConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<LoggingSource> LoggingSources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

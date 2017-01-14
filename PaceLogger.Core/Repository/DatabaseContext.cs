using PaceLogger.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceLogger.Core.Repository {
    internal class DatabaseContext : DbContext {

        // --> TODO: Lesen Foreign Keys
        // https://msdn.microsoft.com/en-us/library/jj591583(v=vs.113).aspx

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Lap> Laps { get; set; }
        public DbSet<Trackpoint> Trackpoints { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

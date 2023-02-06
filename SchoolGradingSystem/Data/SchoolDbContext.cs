using SchoolGradingSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("name=ConnectionString")
        {
        }

        // DbSets Below

        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();

        // NOTE: There is a issue with the database when it is being created, so it cannot be created. Issue states that it comes from a connection-fault or faulty-instance. Will look into it.
    }
}

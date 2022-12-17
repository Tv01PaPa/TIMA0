using Microsoft.EntityFrameworkCore;
using TIMAO.Domain;
using TIMAO.Domain.Model;

namespace TIMAO.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {

        }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
        
        }

    }
}
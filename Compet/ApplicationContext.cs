using Compet.Models;
using Microsoft.EntityFrameworkCore;

namespace Compet
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<ResultsCompititions> ResultsCompititions { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Compet.Models.Event> Event { get; set; } = default!;
    }
}


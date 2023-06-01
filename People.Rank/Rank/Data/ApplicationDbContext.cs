using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rank.Model;
using System.Security.Cryptography.X509Certificates;

namespace Rank.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            
        }

        public DbSet <People> Pleoples { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<TaskEntry>TaskEntries { get; set; }
    }
}
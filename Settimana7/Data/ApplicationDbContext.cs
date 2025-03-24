using Microsoft.EntityFrameworkCore;
using Settimana7.Models;

namespace Settimana7.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            { }

           public DbSet<Student> Students{ get; set; }

        }
    }


using Microsoft.EntityFrameworkCore;
using SimpleERP.Models;

namespace SimpleERP.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; } 
    }
}

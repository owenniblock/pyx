namespace Pyx.Data
{
    using Microsoft.EntityFrameworkCore;
    using Pyx.Data.Entities;
    
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Instruction> Instructions { get; set; }

        public DbSet<Reaction> Reactions { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace CustomeAuth.Entites
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
        
        
            
        
        }

        public DbSet<UserAccount> UsersAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }




    }
}

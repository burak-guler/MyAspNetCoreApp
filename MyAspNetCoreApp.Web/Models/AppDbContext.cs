using Microsoft.EntityFrameworkCore;

namespace MyAspNetCoreApp.Web.Models
{
    //.net 6 ile birlikte startup.cs yerine program.cs geldi.
    //DbContextOptions<AppDbContext> bu AppDbContext nesnesi hangi veritabına gelecek 
    // onu belirleriz, options ise program.cs de belirleriz.
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }    
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Data
{
    public class AppContextDb: IdentityDbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options):base(options){}
    }
}
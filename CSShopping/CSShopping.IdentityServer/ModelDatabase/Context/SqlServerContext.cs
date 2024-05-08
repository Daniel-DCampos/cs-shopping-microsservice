using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSShopping.IdentityServer.ModelDatabase.Context
{
    public class SQLServerContext : IdentityDbContext<ApplicationUser>
    {
        public SQLServerContext() { }
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
    }
}

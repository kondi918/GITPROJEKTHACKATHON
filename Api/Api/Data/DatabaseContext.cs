using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}

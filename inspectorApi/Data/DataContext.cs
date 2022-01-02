using inspectorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace inspectorApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}

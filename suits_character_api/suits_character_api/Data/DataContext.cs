using Microsoft.EntityFrameworkCore;

namespace suits_character_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuitsCharacter> SuitsCharacters => Set<SuitsCharacter>();
    }
}

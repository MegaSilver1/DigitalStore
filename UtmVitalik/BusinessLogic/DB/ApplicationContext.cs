using System.Data.Entity;

namespace UtmVitalik.BusinessLogic.DB
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Actor> Actor { get; set; }
        public DbSet<GameModel> Games { get; set; }
    }
}
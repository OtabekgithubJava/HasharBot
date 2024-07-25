using Microsoft.EntityFrameworkCore;
using UnityBot.Bot.Models.Entities;

namespace UnityBot.Bot.Persistanse
{
    public class UnityDbContext : DbContext
    {
        public UnityDbContext(DbContextOptions<UnityDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}

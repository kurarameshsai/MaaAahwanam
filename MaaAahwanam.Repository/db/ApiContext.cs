using TrackerEnabledDbContext;
using System.Data.Entity;
using MaaAahwanam.Models;

namespace MaaAahwanam.Repository.db
{
    public class ApiContext : TrackerContext
    {
        public ApiContext() : base("name=APIContext")
        {
        }

        public DbSet<UserLogin> MaUserLogin { get; set; }
        public DbSet<UserDetails> MaUserDetails { get; set; }

    }
}

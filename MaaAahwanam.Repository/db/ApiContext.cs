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

        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }

    }
}

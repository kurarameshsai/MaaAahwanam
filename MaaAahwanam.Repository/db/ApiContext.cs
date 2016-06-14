using TrackerEnabledDbContext;
using System.Data.Entity;
using MaaAahwanam.Models;

namespace MaaAahwanam.Dal.db
{
    public class ApiContext : TrackerContext
    {
        public ApiContext() : base("name=APIContext")
        {
        }

        public DbSet<UserLogin> MA_User_Login { get; set; }
        public DbSet<UserDetails> MA_User_Details { get; set; }

    }
}

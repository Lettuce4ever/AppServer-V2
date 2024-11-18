using Microsoft.EntityFrameworkCore;

namespace AppServerGal.Models
{
    public partial class GameDbContext : DbContext
{
        public User? GetUser(string username)
        {
            return this.Users.Where(x => x.Username == username).FirstOrDefault();
        }

}
}

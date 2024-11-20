
namespace AppServerGal.DTO
{
    public class UserLoginDTO
{
    public string Username { get; set; } = null!;
    public string UserPassword { get; set; }

        public UserLoginDTO(AppServerGal.Models.User useri)
        {
            this.Username = useri.Username;
            this.UserPassword = useri.UserPassword;

        }
    }
}

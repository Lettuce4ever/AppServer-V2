
namespace AppServerGal.DTO
{
    public class UserLoginDTO
{
    public string Username { get; set; } = null!;
    public string Email { get; set; }

        public UserLoginDTO(AppServerGal.Models.User useri)
        {
            this.Username = useri.Username;
            this.Email = useri.Email;

        }
    }
}

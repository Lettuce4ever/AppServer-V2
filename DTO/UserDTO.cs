﻿namespace AppServerGal.DTO
{
    public class UserDTO
    {
        public string Username { get; set; } = null!;
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Score { get; set; }
        public int? GamesPlayed { get; set; }
        public int? TypeId { get; set; }

        public UserDTO() { }
        public UserDTO(Models.User useri)
        {
            this.Username = useri.Username;
            this.Email = useri.Email;
            this.FirstName = useri.FirstName;
            this.LastName = useri.LastName;
            this.UserPassword = useri.UserPassword;

        }
    }
}

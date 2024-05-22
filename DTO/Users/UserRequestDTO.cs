using Backend_TeaTech.Enum;

namespace Backend_TeaTech.DTO.Users
{
    public class UserRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRequestDTO() { }
        public UserRequestDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

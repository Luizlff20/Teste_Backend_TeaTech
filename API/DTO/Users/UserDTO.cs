using Backend_TeaTech.Enum;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.DTO.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public Guid? ResponsibleId { get; set; }

        public UserDTO()
        {
        }
        public UserDTO(Guid id, string email, UserType userType, Responsible responsible)
        {
            Id = id;
            Email = email;
            UserType = userType;
            ResponsibleId = responsible.Id;
        }
        public UserDTO(User user)
        {
            Id = user.Id;
            Email = user.Email;
            UserType = user.UserType;
        }
    }
}

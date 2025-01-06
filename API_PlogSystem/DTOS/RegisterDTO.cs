using CoreLayer_BlogSystem.Entities.Enums;

namespace API_BlogSystem.DTOS
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public UserRole Role { get; set; }
    }
}

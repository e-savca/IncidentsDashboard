using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
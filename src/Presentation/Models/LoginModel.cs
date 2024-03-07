using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginModel
    {
        //[Required]
        public string Username { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
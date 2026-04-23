using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.Models.UserCredentials
{
    public class UserCredential
    {
        [Required, MinLength(2)]
        public string Username { get; set; }
        
        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}

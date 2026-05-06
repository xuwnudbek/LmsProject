using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.Models.UserCredentials
{
    public class UserCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Role
{
    public class RoleCreateDto
    {
        [Required]
        public string  Name { get; set; }
    }
}

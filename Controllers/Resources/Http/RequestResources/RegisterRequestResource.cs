using System.ComponentModel.DataAnnotations;

namespace Code.Controllers.Resources.Http.RequestResources
{
    public class RegisterRequestResource
    {
        [Required, StringLength(255)]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(255)]
        public string Password { get; set; }
    }
}
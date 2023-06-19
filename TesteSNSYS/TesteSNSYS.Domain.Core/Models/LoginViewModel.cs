using System.ComponentModel.DataAnnotations;

namespace TesteSNSYS.Domain.Core.Models
{
    public class LoginViewModel
    {
        [Required]
        public string user { get; set; }
        [Required]
        public string passWord { get; set; }
    }
}

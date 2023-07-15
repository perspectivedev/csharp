#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace login_and_registration.Models;

public class LoginUser
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$", ErrorMessage = "Invalid email format.")]
    public string EmailLogin { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string PasswordLogin { get; set; }
}
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace couponclipper_belt_exam_1.Models;

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
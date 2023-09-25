#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace couponclipper_belt_exam_1.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage = "Username is required.")]
    [Display(Name ="Username")]
    [MinLength(3, ErrorMessage="Username must be at least three characters long.")]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    [UniqueEmail]
    [RegularExpression(@"^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least eight characters.")]
    public string Password { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm_Password { get; set; }
    public int CouponId { get; set; }
    public List<CouponAssociation> CouponTracker { get; set; } = new List<CouponAssociation>();
    
public override string ToString()
{
    return String.Format("UN -> {0}, En -> {1}, Cr -> {2}, Up -> {3}", UserName, Email, CreatedAt.ToString(), UpdatedAt.ToString());
}
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required");
        }

        MyContext _db = (MyContext)validationContext.GetService(typeof(MyContext));

        if (_db.Users.Any(user => user.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique");
        } 
        else 
        {
            return ValidationResult.Success;
        }
    }
}
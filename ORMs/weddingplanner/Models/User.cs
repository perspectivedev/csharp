#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace weddingplanner.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage = "First Name is required.")]
    [Display(Name ="First Name")]
    [MinLength(3, ErrorMessage="First Name must be at least three characters long.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required.")]
    [Display(Name ="Last Name")]
    [MinLength(3, ErrorMessage="Last Name must be at least three characters long.")]
    public string LastName { get; set; }
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
    // This does not need to be moved to the bottom
    // But it helps make it clear what is being mapped and what is not
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    // There is also a built-in attribute for comparing two fields we can use!
    public string Confirm_Password { get; set; }
    
public override string ToString()
{
    return String.Format("FN -> {0}, LN -> {1}, En -> {2}, Cr -> {3}, Up -> {4}", FirstName, LastName, Email, CreatedAt.ToString(), UpdatedAt.ToString());
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
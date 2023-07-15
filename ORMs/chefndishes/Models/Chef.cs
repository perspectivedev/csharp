#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chefndishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required(ErrorMessage = "First name is required.")]
    [Display(Name = "First name:")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required.")]
    [Display(Name = "Last name:")]
    public string LastName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [dobValidator]
    [Display(Name = "Date of Birth:")]
    public DateTime Dob { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;    

    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class dobValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if((DateTime?)value > DateTime.Now)
        {
            return new ValidationResult("Invalid date of birth. Please submit a valid date of birth.");
        } else {
            TimeSpan AgeDiff = DateTime.Now.Date - (DateTime)value;
            int Age = AgeDiff.Days/365;
            if(Age < 18)
            {
                return new ValidationResult($"Must be 18 years of age. You are {Age} year of age.");
            } else
                {
                    return  ValidationResult.Success;
                }
        } 
    }
}

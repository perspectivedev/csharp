#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using weddingplanner.Controllers;

namespace weddingplanner.Models;

public class Wedding
{
    [Key]
    public int? WeddingId { get; set; }
    [Required]
    public string WeddingOne { get; set; }
    [Required]
    public string WeddingTwo { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Required]
    public int UserId { get; set; }
    public List<WeddingRsvp> Guests { get; set; } = new List<WeddingRsvp>();
}

public class dobValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if((DateTime?)value > DateTime.Now)
        {
            return new ValidationResult("Required to pick a date.");
        } else {
            DateTime Curr = DateTime.Today;
            int Diff = DateTime.Compare((DateTime)value, Curr);
            if(Diff <= 0)
            {
                return new ValidationResult($"The {Diff} of your wedding plans is required.");
            } else
                {
                    return  ValidationResult.Success;
                }
        } 
    }
}
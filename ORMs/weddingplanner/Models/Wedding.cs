#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingplanner.Model;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    [Required]
    public string WeddingOne { get; set; }
    [Required]
    public string WeddingTwo { get; set; }
    [Required]
    public DateTime Date { get; set; }
}
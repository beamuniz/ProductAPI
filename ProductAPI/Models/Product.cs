using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public int QuantityStock { get; set; }

    [Required(ErrorMessage = "The field {0} is required.")]
    public string? Description { get; set; }
}
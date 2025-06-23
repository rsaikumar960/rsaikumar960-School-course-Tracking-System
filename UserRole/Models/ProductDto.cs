using System.ComponentModel.DataAnnotations;

namespace UserRoles.Models;

public class ProductDto
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Class { get; set; } = "";
    [Required]
    public string Section { get; set; } = "";
    [Required]
   
    public string Mars { get; set; } = "";
}

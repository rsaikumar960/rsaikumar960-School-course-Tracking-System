using System.ComponentModel.DataAnnotations;

namespace UserRoles.Models;

public class Languages
{
    [Key]
    public int Id { get; set; }
    public string StudentName { get; set; } = "";
    public string Course { get; set; } = "";

    public int PhNumber { get; set; } 


}

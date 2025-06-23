using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserRoles.Models
{

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Class { get; set; } = "";
        public string Section { get; set; } = "";
     
        public string Mars { get; set; } = "";
       

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Languages Developer { get; set; }
    }
}
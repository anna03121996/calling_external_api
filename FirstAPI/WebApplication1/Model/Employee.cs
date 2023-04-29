using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool IsEmployee { get; set; }
    }
}

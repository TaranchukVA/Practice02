using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1
{
    public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = "No data";
        public string Email { get; set; } = "No data";
    }
}

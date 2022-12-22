using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1
{
    public class OrderedProducts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PurchaseId { get; set; } = 0;
        public string Name { get; set; } = "No data";
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
    }
}

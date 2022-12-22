using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1
{
    public class Purchases
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderNumber { get; set; } = 0;
        public DateTime RegistrationDate { get; set; } = DateTime.MinValue;
        public decimal Sum { get; set; } = 0;
        public int CustomerId { get; set; } = 0;
    }
}

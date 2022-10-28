namespace Shared.Model.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Destination { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
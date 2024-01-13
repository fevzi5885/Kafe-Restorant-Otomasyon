using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set;}
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Basket> Baskets { get; set; } 

    }
}

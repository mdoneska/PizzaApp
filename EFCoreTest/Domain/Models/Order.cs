using Domain.Enums;
using Domain.Models;

namespace Domain
{
    public class Order : BaseEntity
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string Location { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
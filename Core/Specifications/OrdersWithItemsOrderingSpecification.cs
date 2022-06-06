using Core.Entities.OrderAggregate;

namespace Core.Specifications;

public class OrdersWithItemsOrderingSpecification : BaseSpecification<Order>
{
    public OrdersWithItemsOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
    {
        AddInclude(o => o.OrderItems);
        AddInclude(o => o.DeliveryMethod);
        AddOrderByDescending(o => o.OrderDate);
    }
    
    public OrdersWithItemsOrderingSpecification(int id, string email) 
        : base(o => o.Id == id && o.BuyerEmail == email)
    {
        AddInclude(o => o.OrderItems);
        AddInclude(o => o.DeliveryMethod);
    }
}
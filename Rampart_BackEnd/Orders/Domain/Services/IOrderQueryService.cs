using Rampart_BackEnd.Orders.Domain.Model.Aggregates;
using Rampart_BackEnd.Orders.Domain.Model.Queries;

namespace Rampart_BackEnd.Orders.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    
    Task<IEnumerable<Order>> Handle(GetOrderByCustomerIdQuery query);
    
    Task<Order> Handle(GetOrderByIdQuery query);
    
    Task<IEnumerable<Order>> Handle(GetOrderByStatusQuery query);
}
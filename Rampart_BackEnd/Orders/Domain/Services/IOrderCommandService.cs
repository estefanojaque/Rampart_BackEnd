using Rampart_BackEnd.Orders.Domain.Model.Aggregates;
using Rampart_BackEnd.Orders.Domain.Model.Command;

namespace Rampart_BackEnd.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
    Task<Order?> Handle(UpdateOrderCommand command);
    Task<bool> DeleteOrderAsync(int orderId);
}
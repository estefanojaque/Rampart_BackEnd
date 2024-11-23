using Rampart_BackEnd.Orders.Domain.Model.Command;
using Rampart_BackEnd.Orders.Interfaces.REST.Resource;

namespace Rampart_BackEnd.Orders.Interfaces.REST.Transform.Transform;

//Crear el comando
public class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(resource.customerId, resource.orderDate, resource.deliveryDate, resource.deliveryTime, resource.paymentMethod, resource.status);
    }
}
using System.Collections.Generic;

public class OrderServiceProxy : ServiceBase, IOrderService
{
    private readonly IOrderService _orderService;

    public OrderServiceProxy(IOrderService orderService) 
    : base(new IInvocation[] { new ServiceTimingAspect(), new ServiceExceptionAspect(), new ServiceLogAspect() })
    {
        _orderService = orderService;
    }

    public Order GetOrderById(int Id)
    {
        return base.Intercept(nameof(GetOrderById), () => _orderService.GetOrderById(Id));
    }

    public IList<Order> GetOrders()
    {
        return base.Intercept(nameof(GetOrders), () => _orderService.GetOrders());
    }

    public void Save(Order order)
    {
        base.Intercept(nameof(GetOrders), () => _orderService.Save(order));
    }
}
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;
using TestTask.Models;
using TestTask.Persistence.Data;

namespace TestTask.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public OrderService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<Order> GetOrder()
    {
        var price = await _applicationDbContext.Orders.MaxAsync(o => o.Price);
        return await _applicationDbContext.Orders.FirstOrDefaultAsync(o => o.Price == price);
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _applicationDbContext.Orders.Where(o => o.Quantity > 10).ToListAsync();
    }
}
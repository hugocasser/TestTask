using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;
using TestTask.Models;
using TestTask.Models.Enums;
using TestTask.Persistence.Data;

namespace TestTask.Persistence.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<User> GetUser()
    {
        var orderCount = await _applicationDbContext.Users.MaxAsync(u => u.Orders.Count);
        return await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Orders.Count == orderCount);
    }

    public async Task<List<User>> GetUsers()
    {
        return await _applicationDbContext.Users.Where(o => o.Status == UserStatus.Inactive).ToListAsync();
    }
}
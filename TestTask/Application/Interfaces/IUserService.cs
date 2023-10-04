using TestTask.Models;

namespace TestTask.Application.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser();

        public Task<List<User>> GetUsers();
    }
}

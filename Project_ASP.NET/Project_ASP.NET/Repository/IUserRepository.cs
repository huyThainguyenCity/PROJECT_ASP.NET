using BusinessObject.Models;

namespace Project_ASP.NET.Repository
{
    public interface IUserRepository
    {
        public bool GetUser(string username, string password);

    }
}

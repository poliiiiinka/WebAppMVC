using System.Threading.Tasks;
using WebAppMVC.Models.DB;

namespace WebAppMVC.Models.Interfaces
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}

using System.Threading.Tasks;
using WebAppMVC.Models.DB;

namespace WebAppMVC.Models.Interfaces
{
    public interface IRequestRepository
    {
        Task AddLog(Request request);
        Task<Request[]> GetLog();
    }
}

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAppMVC.Models.DB;
using WebAppMVC.Models.Interfaces;

namespace WebAppMVC.Models.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddLog(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLog()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}

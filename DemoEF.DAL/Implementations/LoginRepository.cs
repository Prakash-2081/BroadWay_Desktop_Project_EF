using Demo.DAL.Interfaces;
using DemoEF.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<int> LoginAsync(string username,string password)
        {
            var count = await _context.Users.CountAsync(x => x.UserName == username && x.Password == password);
            return count;
        }
    }

}


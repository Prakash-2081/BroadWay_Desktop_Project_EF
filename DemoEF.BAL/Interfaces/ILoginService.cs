using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BAL.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}

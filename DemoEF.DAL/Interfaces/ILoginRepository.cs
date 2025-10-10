using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Interfaces
{
    public interface ILoginRepository
    {
        Task<int> LoginAsync(string username,string password);
    }
}

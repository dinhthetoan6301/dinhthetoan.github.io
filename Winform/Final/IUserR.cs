using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public interface IUserR
    {
        Task<bool> Insert(User user);
    }
}

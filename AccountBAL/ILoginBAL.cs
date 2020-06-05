using AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBAL
{
    public interface ILoginBAL
    {
        LoginDto loginService(LoginDto req);
    }
}

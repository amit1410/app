using AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System;
using System.Net.Http;

namespace ApnaKaryala.MiddleLayer.Account
{
    public interface IMLayerLogin
    {
        int SiteId { get; set; }
       Task<LoginDto> loginService(string uname, string password);
    }
}
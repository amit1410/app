using AccountBAL;
using AccountDto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountApi.Controllers
{
    public class LoginController : ApiController
    {

        private readonly ILoginBAL LogiBAL;

       
        public LoginController(ILoginBAL login) 
        {
            LogiBAL = login;
           
        }


        [Route("api/login")]
        [HttpGet, HttpPost]
        public LoginDto loginService([FromBody] LoginDto loginJson)
        {
            LoginDto lg = new LoginDto();
            lg= LogiBAL.loginService(loginJson);
            return lg;
        }

        
    }
}

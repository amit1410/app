using AccountDAL;
using AccountDAL.Account;
using AccountDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBAL
{
    public class LoginBAL:ILoginBAL,IDisposable
    {
        private readonly ApplicationDataContext ApplicationDataContext;

        public LoginBAL()
        {
        }

        public LoginBAL(ApplicationDataContext applicationDataContext)
        {
            ApplicationDataContext = applicationDataContext;
        }

        public void Dispose()
        {
            ApplicationDataContext.Dispose();
        }

        public LoginDto loginService(LoginDto req)
        {
            LoginDto empDTO = new LoginDto();
            try
            {
                var aa = ApplicationDataContext.Login.FirstOrDefault(user =>
          user.UserName.Equals(req.UserName, StringComparison.OrdinalIgnoreCase)
          && user.Password == req.Password);

                var config = new AutoMapper.MapperConfiguration(c => c.CreateMap<Login, LoginDto>());
                var mapper = new Mapper(config);
                empDTO = mapper.Map<LoginDto>(aa);
            }
            catch(Exception ex)
            {

            }
        
            return empDTO;
        }
    }
}

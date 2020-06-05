using AccountDto;
using ApnaKaryala.MiddleLayer.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApnaKaryala.Controllers
{
    public class LoginController : Controller
    {
      
      
        public ActionResult Index()
        {
            LoginDto lg = new LoginDto();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(LoginDto obj)
        {
            var acc = await loginService(obj.UserName, obj.Password);
            if(acc.EmployeeId!=0)
            {
                return View("Dashboard");
            }
            else
            {
                ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
                return View("Index",obj);
            }
            
        }

        public ActionResult Dashboard()
        {
            LoginDto lg = new LoginDto();
            return View();
        }

        public async Task<LoginDto> loginService(string uname, string password)
        {
            LoginDto dt = new LoginDto();
            LoginDto retdto = new LoginDto();
            try
            {
                dt.SiteId = 1;
                dt.UserName = uname;
                dt.Password = password;

                // ApiClient apiClient = new ApiClient(new Uri(ConfigurationManager.AppSettings["AccountApiUrl"]));
                // using (var stringContent = new StringContent("{ \"UserName\": \"John\" }", System.Text.Encoding.UTF8, "application/json"))
                var myContent = JsonConvert.SerializeObject(dt);
                var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(ConfigurationManager.AppSettings["AccountApiUrl"], stringContent).ConfigureAwait(false); ;
                        var result = response.Content.ReadAsStringAsync().Result;
                        if (response.IsSuccessStatusCode)
                        {
                            retdto = JsonConvert.DeserializeObject<LoginDto>(result.ToString());
                            //HttpContent newvar = response.Content.ReadAsAsync<LoginDto>();
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

            }


            return retdto;
        }
    }
}
using AccountDAL.Account;
using AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ApnaKaryala.MiddleLayer.Account
{
    public class MLayerLogin: IMLayerLogin
    {
        public int SiteId
        {
            get; set;
        }
        public async Task<LoginDto> loginService(string uname,string password)
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
                        HttpResponseMessage response =await client.PostAsync(ConfigurationManager.AppSettings["AccountApiUrl"], stringContent).ConfigureAwait(false); ;
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
using appcenubbroyler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appcenubbroyler.Provider
{
    class ServiceManager
    {
        //private string Url = "http://192.168.2.7/api/Users/";
        HttpClient client;
        public ServiceManager()
        {
            client = new HttpClient();
#if DEBUG
            //client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }

       
        public async Task<List<Users>> GetAll()
        {

            Uri Url = new Uri(string.Format(RestUrl.RestUrlAdress + "getallusers", string.Empty));
            List<Users> userslist = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(Url);
                if (response.IsSuccessStatusCode)
                {
                    string mobileResult1 = await response.Content.ReadAsStringAsync();
                    MobileResult mobileResult2 = JsonConvert.DeserializeObject<MobileResult>(mobileResult1);
                    userslist = JsonConvert.DeserializeObject<List<Users>>
                    (mobileResult2.Data.ToString());
                    Debug.WriteLine(@"\getalluser successfully(ugurlu)");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return userslist;
        }
        public async Task<MobileResult> Insert(Users users)
        {
            Uri Url = new Uri(string.Format(RestUrl.RestUrlAdress + "insert", string.Empty));
            MobileResult result = null;
            try
            {
                string json = JsonConvert.SerializeObject(users);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(Url, content);
                string mobileresult = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<MobileResult>(mobileresult);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\insert successfully(ugurlu).");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return result;
        }
        public async Task<MobileResult> Update(Users users)
        {
            Uri Url = new Uri(string.Format(RestUrl.RestUrlAdress + "update", string.Empty));
            MobileResult result = null;
            try
            {
                string json = JsonConvert.SerializeObject(users);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(Url, content);
                string mobileresult = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<MobileResult>(mobileresult);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\update successfully(ugurlu).");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return result;
        }

        public async Task<MobileResult> Delete(Users users)
        {
            
            Uri Url = new Uri(string.Format(RestUrl.RestUrlAdress + "delete", users));
            MobileResult result = null;
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(Url);
                string mobileresult = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<MobileResult>(mobileresult);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\delete successfully(ugurlu).");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return result;
        }
    }
}

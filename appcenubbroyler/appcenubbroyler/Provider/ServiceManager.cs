using appcenubbroyler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace appcenubbroyler.Provider
{
    class ServiceManager
    {
        private string Url = "http://192.168.2.5/api/Users/";
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            return client;
        }
        public async Task<List<Users>> GetAll()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "getallusers");
            MobileResult mobileResult = 
                JsonConvert.DeserializeObject<MobileResult>(result);
            return JsonConvert.DeserializeObject<List<Users>>
                (mobileResult.Data.ToString());
        }
        public async Task<MobileResult> Process(Users users, string processType)
        {
            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url + processType,
                new StringContent(JsonConvert.SerializeObject(users),Encoding.UTF8, 
                "application/json"));
            var mobileresult = await response.Content.ReadAsStringAsync();
            MobileResult result = JsonConvert.DeserializeObject<MobileResult>(mobileresult);
            return result;
        }

        public async Task<MobileResult> Insert(Users model)
        {
            return await Process(model, "insert");
        }

        public async Task<MobileResult> Delete(Users model)
        {
            return await Process(model, "delete");
        }

        public async Task<MobileResult> Update(Users model)
        {
            return await Process(model, "update");
        }
    }
}

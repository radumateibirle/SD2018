using BLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HomeService
    {
        string Baseurl = "http://localhost:58554/";
        public async Task<string> Login(string email,string pw)
        {
            UserModelAPI objUser = new UserModelAPI();
            objUser.Email = email;
            objUser.Password = pw;
            string obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Login");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(objUser), Encoding.ASCII, "application/json");
                var Res = await client.PostAsync(Req.RequestUri, Req.Content);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<string>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }
    }
}

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
    public class UserServices
    {
        string Baseurl = "http://localhost:58554/";
        public async Task<List<UserModel>> getAll()
        {
            List<UserModel> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Users");
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<UserModel>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }

        public async void deleteByID(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Delete, Baseurl + "api/Users/" + ID);
                var Res = await client.DeleteAsync(Req.RequestUri);
            }
        }

        public async void addUser(string type, string email)
        {
            var user = new UserModel { Type = type, Email = email };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Users");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user), Encoding.ASCII, "application/json");
                var Res = await client.PostAsync(Req.RequestUri, Req.Content);
            }
        }

        public async void update(UserModel um)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Put, Baseurl + "api/Users/Update");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(um), Encoding.ASCII, "application/json");
                var Res = await client.PutAsync(Req.RequestUri, Req.Content);
            }
        }
    }
}

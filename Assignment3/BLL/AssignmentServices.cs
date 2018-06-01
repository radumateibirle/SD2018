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
    public class AssignmentServices
    {
        string Baseurl = "http://localhost:58554/";
        public async Task<List<AssignmentModel>> getAll()
        {
            List<AssignmentModel> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Assignment");
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<AssignmentModel>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }

        public async void addAssignment(AssignmentModelAPI assign)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Assignment");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(assign), Encoding.ASCII, "application/json");
                var Res = await client.PostAsync(Req.RequestUri, Req.Content);
            }
        }

        public async void update(AssignmentModel am)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Put, Baseurl + "api/Assignment/Edit");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(am), Encoding.ASCII, "application/json");
                var Res = await client.PutAsync(Req.RequestUri, Req.Content);
            }
        }

        public async void deleteByID(int ID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Delete, Baseurl + "api/Assignment/" + ID);
                var Res = await client.DeleteAsync(Req.RequestUri);
            }
        }
    }
}

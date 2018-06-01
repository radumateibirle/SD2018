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
    public class LaboratoryServices
    {
        string Baseurl = "http://localhost:58554/";
        public async Task<List<LaboratoryModel>> getAll()
        {
            List<LaboratoryModel> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Laboratory");
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<LaboratoryModel>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }
        public async Task<List<LaboratoryModel>> getByKeyword(string keyword)
        {
            List<LaboratoryModel> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Laboratory/"+keyword);
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<LaboratoryModel>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }

        public async void addLaboratory(LaboratoryModelAPI lab)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Laboratory");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(lab), Encoding.ASCII, "application/json");
                var Res = await client.PostAsync(Req.RequestUri, Req.Content);
            }
        }

        public async void update(LaboratoryModel lm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Put, Baseurl + "api/Laboratory");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(lm), Encoding.ASCII, "application/json");
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
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Delete, Baseurl + "api/Laboratory/" + ID);
                var Res = await client.DeleteAsync(Req.RequestUri);
            }
        }
    }
}

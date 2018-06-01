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
    public class SubmissionServices
    {
        string Baseurl = "http://localhost:58554/";
        public async Task<List<SubmissionModel>> getAll()
        {
            List<SubmissionModel> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Submission");
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<SubmissionModel>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }

        public async Task<List<SubmissionModelAPI>> getByAssignmentID(int ID)
        {
            List<SubmissionModelAPI> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Submission/Grades/"+ID);
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<SubmissionModelAPI>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }

        public async void update(SubmissionModel sm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Put, Baseurl + "api/Submission/Edit");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(sm), Encoding.ASCII, "application/json");
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
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Delete, Baseurl + "api/Submission/" + ID);
                var Res = await client.DeleteAsync(Req.RequestUri);
            }
        }

        public async void addSubmission(SubmissionModelAPI sub)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Submission");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(sub), Encoding.ASCII, "application/json");
                var Res = await client.PostAsync(Req.RequestUri, Req.Content);
            }
        }

    }
}

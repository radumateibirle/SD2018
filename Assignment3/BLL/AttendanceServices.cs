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
    public class AttendanceServices
    {
        string Baseurl = "http://localhost:58554/";
        public async Task<List<AttendanceModel>> getAll()
        {
            List<AttendanceModel> obj;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Get, Baseurl + "api/Attendance");
                var Res = await client.GetAsync(Req.RequestUri);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<List<AttendanceModel>>(EmpResponse);
                    return obj;
                }
            }
            return null;
        }

        public async void update(AttendanceModel sm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Put, Baseurl + "api/Attendance/Edit");
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
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Delete, Baseurl + "api/Attendance/" + ID);
                var Res = await client.DeleteAsync(Req.RequestUri);
            }
        }

        public async void addAttendance(AttendanceModelAPI att)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage Req = new HttpRequestMessage(HttpMethod.Post, Baseurl + "api/Attendance");
                Req.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(att), Encoding.ASCII, "application/json");
                var Res = await client.PostAsync(Req.RequestUri, Req.Content);
            }
        }
    }
}

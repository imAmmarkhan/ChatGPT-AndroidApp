using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Model.Model;
using Newtonsoft.Json;

namespace Model.Services
{
    class ApiService
    {
        public async Task<Root> ApiResponse(string _Query)
        {
            string Query= _Query;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://chatgpt-api8.p.rapidapi.com/"),
                Headers =
                {
                    { "X-RapidAPI-Key", "f46530eab5mshb488043f265909ep19b9ffjsne1debe6fc992" },
                    { "X-RapidAPI-Host", "chatgpt-api8.p.rapidapi.com" },
                },
                Content = new StringContent("[\r\n    {\r\n        \"content\": \"'"+Query+"'\",\r\n        \"role\": \"user\"\r\n    }\r\n]")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            var response = client.Send(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(body);
            return root;
            
        }
    }
}

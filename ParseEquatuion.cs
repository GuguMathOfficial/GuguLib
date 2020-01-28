using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class ParseEquatuion
    {
        async void Parse()
        {
            var filePath = "image1.png";
            string id = "bonka_7335_gmail_com";
            string apiKey = "9163788845ba5f23cd6c";
            char mark = (char)39;

            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("app_id", id);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("app_key", apiKey);

                var data = File.ReadAllBytes(filePath);
                var base64 = Convert.ToBase64String(data);
                var imageUri = "data:image/jpg;base64," + base64;
                var json = JsonConvert.SerializeObject(new { src = imageUri });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.mathpix.com/v3/text", content);
                Console.WriteLine(JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()));
            }
        }
    }
}

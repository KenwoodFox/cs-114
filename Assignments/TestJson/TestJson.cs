// TestJson
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

// Alias
using con = System.Console;

namespace TestJson
{
    class TestJson
    {
        static void Main(string[] args)
        {
            string url = "https://snub.kitsunehosting.net/cmds/version";

            con.WriteLine($"Im going to try and fetch the endpoint for {url}");

            // Using a webclient (wc)
            string json;
            using (WebClient wc = new WebClient())
            {
                // Get the json
                json = wc.DownloadString(url);
            }

            con.WriteLine($"Response was {json}");

            Dictionary<string, string> p =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            // List<string>? p = JsonConvert.DeserializeObject<List<string>>(json);
            con.WriteLine(p["version"]);
        }
    }
}

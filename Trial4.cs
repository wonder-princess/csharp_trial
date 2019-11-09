using System;
using System.Net.Http;
using System.IO;

namespace csharp_trial
{
    public class Class4
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            string uri = "https://avatars2.githubusercontent.com/u/54895094?s=400&u=bde011ea592bd96683771735af0c9c0616f687ad&v=4";
            string outputPath = "C:\\Users\\sekai\\Documents\\img.jpg";

            HttpResponseMessage res = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            using (var fileStream = File.Create(outputPath)) ;
            {
                using (var httpStream = await res.Content.ReadAsStreamAsync())
                {
                    httpStream.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;

namespace GitHub_Search_Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gitHubData = new Dictionary<string, string>();

            string uri = "https://github.com/wonder-princess?repositories";
            string username = "wonder-princess";
            string password = "";
            string appName = "csharp_trial";

            gitHubData.Add("uri", uri);
            gitHubData.Add("username", username);
            gitHubData.Add("password", password);
            gitHubData.Add("appName", appName);

            //        string outputPath = "C:\\Users\\sekai\\Documents\\img.jpg";
            //        DownloadImgAsync(uri, outputPath);

            DownloadGitHubAsync(gitHubData);

            Console.ReadLine();


        }

        static async void DownloadImgAsync(string imgUri, string outputPath)
        {
            var client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(imgUri, HttpCompletionOption.ResponseHeadersRead);
            using (var fileStream = File.Create(outputPath))
            using (var httpStream = await res.Content.ReadAsStreamAsync())
                httpStream.CopyTo(fileStream);

        }
        static async void DownloadGitHubAsync(Dictionary<string, string> gitGHubData)
        {
            var ghe = new Uri(gitGHubData["uri"]);
            var client = new GitHubClient(new ProductHeaderValue(gitGHubData["appNAme"]), ghe);
            var basicAuth = new Credentials(gitGHubData["username"], gitGHubData["password"]);
            client.Credentials = basicAuth;

            var user = await client.User.Get(gitGHubData["username"]);
            Console.WriteLine("{0} has {1} public repositories - go check out their profile at {2}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StringApiClient
{
	class Program
	{

        static HttpClient client = new HttpClient();
		static void Main(string[] args)
		{
			InputWrapper iw = new InputWrapper();
			InitHttpClient();
			Show();
			string cmd = iw.getString("> ");
			while (cmd != "quit")
			{
				if (cmd == "show")
					Show();
				else if (cmd == "showone")
				{
					int id = iw.getInt("index: ");
					ShowOne(id);
				}
				else if (cmd == "add")
				{
					string str = iw.getString("string: ");
					Uri uriString = Add(str);
                    Console.WriteLine($"uriString = {uriString}");
				}
				else if (cmd == "update")
				{
					int id = iw.getInt("index: ");
					string str = iw.getString("string: ");
                    Uri stringUri;
                    if (Uri.TryCreate(client.BaseAddress, $"/api/strings/{id}", out stringUri))
                    {
                        Console.WriteLine($"stringUri = {stringUri}");
                        Update(stringUri, str);
                    }
                    else Console.WriteLine("Could not create Uri");
				}
				else if (cmd == "delete")
				{
					int id = iw.getInt("index: ");
                    Uri stringUri;
                    if (Uri.TryCreate(client.BaseAddress, $"/api/strings/{id}", out stringUri))
                    {
                        Console.WriteLine($"stringUri = {stringUri}");
                        Delete(stringUri);
                    }
                    else Console.WriteLine("Could not create Uri");
                }
				else
				{
					Console.WriteLine("Legal commands are:");
					Console.WriteLine("\tshow");
					Console.WriteLine("\tshowone");
					Console.WriteLine("\tadd");
					Console.WriteLine("\tupdate");
					Console.WriteLine("\tdelete");
					Console.WriteLine("\tquit");
				}
				cmd = iw.getString("> ");
			}
		}

		private static void InitHttpClient()
		{
            client.BaseAddress = new Uri("http://localhost:59904/");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}

		private static void Show()
		{
            HttpResponseMessage response = client.GetAsync("api/strings").Result;
            if (response.IsSuccessStatusCode)
            {
                var strings = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
                foreach (var s in strings)
                    Console.WriteLine(s);
            }
            else
            {
                Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
            }
		}

		private static void ShowOne(int id)
		{
            HttpResponseMessage response = client.GetAsync($"api/strings/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var s = response.Content.ReadAsAsync<string>().Result;
                Console.WriteLine(s);
            }
            else
            {
                Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
            }
        }

		private static Uri Add(string str)
		{
            Uri uriString = null;
            HttpResponseMessage response = client.PostAsJsonAsync("api/strings/", str).Result;
            if (response.IsSuccessStatusCode)
            {
                uriString = response.Headers.Location;
                return uriString;
            }
            else
            {
                Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
                return null;
            }
		}

		private static void Update(Uri stringUri, string str)
		{
            HttpResponseMessage response = client.PutAsJsonAsync(stringUri.PathAndQuery, str).Result;
            Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
        }

		private static void Delete(Uri stringUri)
		{
            HttpResponseMessage response = client.DeleteAsync(stringUri).Result;
            Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
        }
	}
}

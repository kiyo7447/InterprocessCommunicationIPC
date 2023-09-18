using System;
using System.Net.Http;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// クライアントサイド
using (var client = new HttpClient())
{
    var response = await client.GetAsync("http://localhost:5017");
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}

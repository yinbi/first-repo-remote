using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:49427/");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var task = client.GetAsync("http://localhost:5000/api/Customers/1");
            task.ContinueWith(
                t =>
                {
                    t.Result.Content.ReadAsStringAsync().ContinueWith(
                        tt =>
                        {
                            Console.WriteLine(tt.Result);
                        });
                });
            GetCustomer2();
            AddingNew();
            Console.ReadLine();
        }

        private static void AddingNew()
        {
            var client = new HttpClient();
            //...
        }

        private static async void GetCustomer2()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Customers/2");
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }
    }
}

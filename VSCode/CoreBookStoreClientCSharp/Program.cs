using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace CoreBookStoreClientCSharp
{
    public class Category
    {
        public int categoryID {set; get;}
        public String name {set; get;}
    }
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task GetData()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            
            var stringTask = client.GetStringAsync("http://localhost:5000/api/Category/");

            var msg = await stringTask;
            Console.WriteLine(msg);
        }

        static async Task GetData(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            
            var stringTask = client.GetStringAsync($"http://localhost:5000/api/Category/{id}");

            var msg = await stringTask;
            Console.WriteLine(msg);
        }

        static async Task GetStreamData()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            
            var streamTask = client.GetStreamAsync("http://localhost:5000/api/Category/");
            var serializer = new DataContractJsonSerializer(typeof(List<Category>));
            var data = serializer.ReadObject(await streamTask) as List<Category>;

            foreach (Category item in data){
                Console.WriteLine(item.categoryID + " " + item.name);
            }
        }

        static async Task GetStreamData(int id)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            
            var streamTask = client.GetStreamAsync($"http://localhost:5000/api/Category/{id}");
            var serializer = new DataContractJsonSerializer(typeof(Category));
            var item = serializer.ReadObject(await streamTask) as Category;

            Console.WriteLine(item.categoryID + " " + item.name);
        }

        static async Task<Uri> CreateDataAsync(Category item)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:5000/api/Category/", item);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        static async Task<Category> UpdateDatatAsync(Category item)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"http://localhost:5000/api/Category/{item.categoryID}", item);
            response.EnsureSuccessStatusCode();

            item = await response.Content.ReadAsAsync<Category>();
            return item;
        }

        static async Task<HttpStatusCode> DeleteDataAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost:5000/api/Category/{id}");
            return response.StatusCode;
        }

        static async Task RunAsync()
        {
            await GetData();
            
            Console.WriteLine("");
            Console.WriteLine("");
            
            await GetData(1);
            
            Console.WriteLine("");
            Console.WriteLine("");
            
            await GetStreamData();
            
            Console.WriteLine("");
            Console.WriteLine("");
            
            await GetStreamData(2);
            
            Console.WriteLine("");
            Console.WriteLine("");

            Category item = new Category
            {
                name = "Fisika"
            };
            await CreateDataAsync(item);
            await GetStreamData();

            Console.WriteLine("");
            Console.WriteLine("");

            Category itemUpdate = new Category
            {
                categoryID = 9,
                name = "Biologi"
            };
            await UpdateDatatAsync(itemUpdate);
            await GetStreamData();

            Console.WriteLine("");
            Console.WriteLine("");
            await DeleteDataAsync(10);
            await GetStreamData();
        }

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }
    }
}

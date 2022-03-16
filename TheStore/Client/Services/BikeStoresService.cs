using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TheStore.Shared;

namespace TheStore.Client.Services
{
    public class BikeStoresService : IBikeStoresService
    {
        public BikeStoresService()
        {

        }

        private readonly HttpClient _httpClient;
        public event Action OnChange;

        public List<Store> Stores { get; set; } = new List<Store>(); 
        public BikeStoresService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Store> GetSingleBikeStore(int id)
        {
            return await _httpClient.GetFromJsonAsync<Store>($"api/bikestore/{id}");

        }

        public async Task GetBikeStores()
        {
            var result =  await _httpClient.GetFromJsonAsync<List<Store>>("api/bikestore");
            if (result != null)
                Stores = result;
        }

        //public async Task<List<Store>> CreateBikeStore(Store store)
        //{
        //    var content = new StringContent(JsonSerializer.Serialize(store),
        //                                    Encoding.UTF8,
        //                                    "application/json");
        //    var result = await _httpClient.PostAsJsonAsync("api/bikestore", content);
        //    var stores = await result.Content.ReadFromJsonAsync<List<Store>>();
        //    OnChange.Invoke();
        //    return stores;
        //}

        public async Task CreateBikeStore(Store store)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(store);
                //var data = new StringContent(json, Encoding.UTF8, "application/json");
                //var result = await _httpClient.PostAsJsonAsync("api/bikestore", data);

                //var response = await _httpClient.PostAsJsonAsync("api/bikestore", store);
                //response.EnsureSuccessStatusCode();

                //StringContent content = new StringContent(JsonConvert.SerializeObject(new Store { name = "Test", city = "Smolyan" }), Encoding.UTF8, "application/json");
                //var response = _httpClient.PostAsync("api/bikestore", content).Result;
                //var result = response.Content.ReadAsStringAsync();

                var response = await _httpClient.PostAsync("api/bikestore",
    new StringContent(JsonConvert.SerializeObject(new Store { name = "Test", city = "Smolyan" }))
    {
        Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
    });

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

        //private async Task SetBikeStore(HttpResponseMessage result)
        //{
        //    var response = await result.Content.ReadFromJsonAsync<List<Store>>();
        //    Stores = response;
        //    //_navigationManager.NavigateTo("superheroes");
        //}

        //public Task SetBikeStore(Store store)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

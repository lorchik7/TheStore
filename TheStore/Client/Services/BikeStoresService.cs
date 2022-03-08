using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheStore.Shared;

namespace TheStore.Client.Services
{
    public class BikeStoresService : IBikeStoresService
    {
        private readonly HttpClient _httpClient;

        public List<Store> Stores { get; set; } = new List<Store>();
        public BikeStoresService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Store> GetSingleBikeStore(int id)
        {
            return await _httpClient.GetFromJsonAsync<Store>($"api/bikestore/{id}");

        }

        public async Task<List<Store>> GetBikeStores()
        {
            return await _httpClient.GetFromJsonAsync<List<Store>>("api/bikestore"); ;
        }

        public async Task<List<Store>> CreateBikeStore(Store store)
        {
            var content = new StringContent(JsonSerializer.Serialize(store), Encoding.UTF8, "application/json");
            //TODO:  PostAsJsonAsync/PostAsync nulls the values; needs a fix
            var result = await _httpClient.PostAsJsonAsync("api/bikestore", content);
            var stores = await result.Content.ReadFromJsonAsync<List<Store>>();
            return stores;
        }
    }
}

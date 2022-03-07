using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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
    }
}

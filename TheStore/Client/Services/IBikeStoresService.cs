using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheStore.Client;
using TheStore.Shared;

namespace TheStore.Client.Services
{
    public interface IBikeStoresService
    {
        event Action OnChange;
        List<Store> Stores { get; set; }
        Task GetBikeStores();
        Task<Store> GetSingleBikeStore(int id);
        Task CreateBikeStore(Store store);
        //Task SetBikeStore(Store store);
        //Task UpdateBikeStore(Store store);
    }

}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheStore.Shared;

namespace TheStore.Client.Services
{
    public interface IBikeStoresService
    {
        Task<List<Store>> GetBikeStores();
        Task<Store> GetSingleBikeStore(int id);
    }

}

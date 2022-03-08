using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheStore.Shared;

namespace TheStore.Server.Controllers
{
    [Route("api/[controller]")]
    public class BikeStoreController : ControllerBase
    {
        static List<Store> stores = new List<Store> {
                new Store { Id = 1, StoreName = "The Bike", City = "Sofia" },
                new Store { Id = 2, StoreName = "Pimp My Bike", City = "Smolyan"},
        };

        [HttpGet]
        public async Task<IActionResult> GetBikeStores()
        {
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleSuperHero(int id)
        {
            var store = stores.FirstOrDefault(s => s.Id == id);
            if (store == null)
            {
                return NotFound("Store wasn't found.");
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBikeStore(Store store)
        {
            store.Id = stores.Max(s => s.Id + 1);
            stores.Add(store);
            return Ok(stores);
        }

    }
}

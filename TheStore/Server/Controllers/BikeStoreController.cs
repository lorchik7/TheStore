using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheStore.Server.Data;
using TheStore.Shared;

namespace TheStore.Server.Controllers
{
    [Route("api/[controller]")]
    public class BikeStoreController : Controller
    {
        static List<Store> stores = new List<Store> {
                new Store { id = 1, name = "The Bike", city = "Sofia" },
                new Store { id = 2, name = "Pimp My Bike", city = "Smolyan"},
        };
        private readonly DataContext _context;

        public BikeStoreController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBikeStores()
        {
            return Ok(await _context.Stores.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleBikeStore(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(s => s.id == id);
            if (store == null)
            {
                return NotFound("Store wasn't found.");
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBikeStoreAsync(Store store)
        {
            //store.Id = 23;
            //stores.Add(store);
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return Ok(await _context.Stores.ToListAsync());
        }



    }
}

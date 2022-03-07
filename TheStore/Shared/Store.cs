using System;
using System.ComponentModel.DataAnnotations;

namespace TheStore.Shared
{
    public class Store
    {
        [Key]
        public int Id { get; set; } = 0;
        public string StoreName { get; set; }
        public string City { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheStore.Shared
{
    [Table("stores", Schema = "sales")]
    public class Store
    {
        [Key]
        [Column("store_id", TypeName = "int")]
        public int id { get; set; } = 0;

        [Column("store_name", TypeName = "varchar")]
        public string name { get; set; }

        [Column("city", TypeName = "varchar")]
        public string city { get; set; }
    }
}

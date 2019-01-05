using System;
using System.Collections.Generic;

namespace DvdRental.Data
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rental = new HashSet<Rental>();
        }

        public int InventoryId { get; set; }
        public int FilmId { get; set; }
        public int StoreId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Film Film { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DvdRental.Data
{
    public partial class Store
    {
        public int StoreId { get; set; }
        public int ManagerStaffId { get; set; }
        public int AddressId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Address Address { get; set; }
        public virtual Staff ManagerStaff { get; set; }
    }
}

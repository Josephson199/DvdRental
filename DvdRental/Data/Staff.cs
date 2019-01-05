﻿using System;
using System.Collections.Generic;

namespace DvdRental.Data
{
    public partial class Staff
    {
        public Staff()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public int StoreId { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdate { get; set; }
        public byte[] Picture { get; set; }

        public virtual Address Address { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
    }
}

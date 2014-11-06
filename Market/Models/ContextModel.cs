using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext()
            : base("DefaultConnection")
        {
        }

        public static MarketDbContext Create()
        {
            return new MarketDbContext();
        }

        public System.Data.Entity.DbSet<Market.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Market.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Market.Models.Contact> Contacts { get; set; }
    }
}
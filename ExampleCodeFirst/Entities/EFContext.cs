using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCodeFirst.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("ShopConDB")
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}

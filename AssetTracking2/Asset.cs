using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking2
{
    internal class Asset
    {
        public int Id { get; set; } //Key
        public string? Type { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateTime Purchasedate { get; set; }
        public double PriceUSD { get; set; }

        public Office? Office { get; set; }
        public int OfficeId { get; set; } //Foreign key
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SapEthereumIntegration.Api.Models
{
    public class MarketEntryDisplayModel
    {
        public string SystemId { get; set; }
        public string RawMaterial { get; set; }
        public string Kilos { get; set; }
        public string UsdPerKilo { get; set; }
        public string Status { get; set; }
        public string SellerContactEmail { get; set; }
    }
}

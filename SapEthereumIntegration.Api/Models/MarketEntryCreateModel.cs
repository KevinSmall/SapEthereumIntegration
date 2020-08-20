using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SapEthereumIntegration.Api.Models
{
    public class MarketEntryCreateModel
    {
        public string SystemId { get; set; }
        public string RawMaterial { get; set; }
        public long Kilos { get; set; }
        public long UsdPerKilo { get; set; }
    }
}

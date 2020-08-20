using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace SapEthereumIntegration.Contracts.RawMaterialMarket.ContractDefinition
{
    public partial class MarketEntry : MarketEntryBase { }

    public class MarketEntryBase 
    {
        [Parameter("bytes32", "systemId", 1)]
        public virtual byte[] SystemId { get; set; }
        [Parameter("bytes32", "rawMaterial", 2)]
        public virtual byte[] RawMaterial { get; set; }
        [Parameter("uint256", "kilos", 3)]
        public virtual BigInteger Kilos { get; set; }
        [Parameter("uint256", "usdPerKilo", 4)]
        public virtual BigInteger UsdPerKilo { get; set; }
        [Parameter("bytes32", "status", 5)]
        public virtual byte[] Status { get; set; }
        [Parameter("bytes32", "sellerContactEmail", 6)]
        public virtual byte[] SellerContactEmail { get; set; }
    }
}

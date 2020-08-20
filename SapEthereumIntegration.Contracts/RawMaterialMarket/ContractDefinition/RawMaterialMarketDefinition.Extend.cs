using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SapEthereumIntegration.Contracts.RawMaterialMarket.ContractDefinition
{
    public partial class MarketEntriesOutputDTO
    {
        [Parameter("bytes32", "systemId", 1)]
        public new string SystemId { get; set; }


        [Parameter("bytes32", "rawMaterial", 2)]
        public new string RawMaterial { get; set; }


        [Parameter("uint256", "kilos", 3)]
        public new BigInteger Kilos { get; set; }


        [Parameter("uint256", "usdPerKilo", 4)]
        public new BigInteger UsdPerKilo { get; set; }


        [Parameter("bytes32", "status", 5)]
        public new string Status { get; set; }


        [Parameter("bytes32", "sellerContactEmail", 6)]
        public new string SellerContactEmail { get; set; }
    }
}

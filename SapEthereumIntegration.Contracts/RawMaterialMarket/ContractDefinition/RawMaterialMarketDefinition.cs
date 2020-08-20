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


    public partial class RawMaterialMarketDeployment : RawMaterialMarketDeploymentBase
    {
        public RawMaterialMarketDeployment() : base(BYTECODE) { }
        public RawMaterialMarketDeployment(string byteCode) : base(byteCode) { }
    }

    public class RawMaterialMarketDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610553806100206000396000f3fe608060405234801561001057600080fd5b50600436106100575760003560e01c80633dbe70bb1461005c5780637d4cb9641461007a578063a64303771461008f578063b7fc5cd914610097578063f14aa3fc146100ac575b600080fd5b6100646100d1565b6040516100719190610514565b60405180910390f35b6100826100d8565b6040516100719190610505565b6100646100dd565b6100aa6100a53660046103e2565b6100e4565b005b6100bf6100ba366004610413565b610354565b6040516100719695949392919061042b565b6101805481565b604081565b6101815481565b6100f2565b60405180910390fd5b600082116101125760405162461bcd60e51b81526004016100e99061048a565b600081116101325760405162461bcd60e51b81526004016100e990610453565b61013a6103ad565b8481526020808201859052604080830185905260608301849052805180820190915260038152624e455760e81b918101919091526101779061038b565b6080820152604080518082019091526005815264454d50545960d81b60208201526101a19061038b565b60a0820152610181548190600090604081106101b957fe5b60060201600082015181600001556020820151816001015560408201518160020155606082015181600301556080820151816004015560a08201518160050155905050806020015181600001517fddd2a2c4322c3b451c0e908f427aa7e451f63ddf88df07ab2558505aced4010b8360405161023591906104c1565b60405180910390a36102656040518060400160405280600781526020016613505510d2115160ca1b81525061038b565b608082015260408051808201909152600681526518dbd8901b1d60d21b60208201526102909061038b565b60a0820152610181548190600090604081106102a857fe5b60060201600082015181600001556020820151816001015560408201518160020155606082015181600301556080820151816004015560a0820151816005015590505080600001517f37d78df65c76a1035e7c5de5d77d4a9aaabae62271c538b9cf83384fe0aece2d8260405161031f91906104c1565b60405180910390a261018180546001908101918290556101808054909101905560401161034d576000610181555b5050505050565b6000816040811061036157fe5b60060201805460018201546002830154600384015460048501546005909501549395509193909286565b805160009082906103a05750600090506103a8565b505060208101515b919050565b6040805160c081018252600080825260208201819052918101829052606081018290526080810182905260a081019190915290565b600080600080608085870312156103f7578384fd5b5050823594602084013594506040840135936060013592509050565b600060208284031215610424578081fd5b5035919050565b958652602086019490945260408501929092526060840152608083015260a082015260c00190565b6020808252601e908201527f55534420706572204b696c6f206d757374206265207370656369666965640000604082015260600190565b60208082526017908201527f4b696c6f73206d75737420626520737065636966696564000000000000000000604082015260600190565b600060c082019050825182526020830151602083015260408301516040830152606083015160608301526080830151608083015260a083015160a083015292915050565b61ffff91909116815260200190565b9081526020019056fea2646970667358221220db763fa5654a58e1cc92f83b956e4d171d57f2191e20f17712fda43ed2e451d764736f6c63430006090033";
        public RawMaterialMarketDeploymentBase() : base(BYTECODE) { }
        public RawMaterialMarketDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class MAX_ENTRIESFunction : MAX_ENTRIESFunctionBase { }

    [Function("MAX_ENTRIES", "uint16")]
    public class MAX_ENTRIESFunctionBase : FunctionMessage
    {

    }

    public partial class CreateBuyOfferFunction : CreateBuyOfferFunctionBase { }

    [Function("createBuyOffer")]
    public class CreateBuyOfferFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "systemId", 1)]
        public virtual byte[] SystemId { get; set; }
        [Parameter("bytes32", "rawMaterial", 2)]
        public virtual byte[] RawMaterial { get; set; }
        [Parameter("uint256", "kilos", 3)]
        public virtual BigInteger Kilos { get; set; }
        [Parameter("uint256", "usdPerKilo", 4)]
        public virtual BigInteger UsdPerKilo { get; set; }
    }

    public partial class MarketEntriesFunction : MarketEntriesFunctionBase { }

    [Function("marketEntries", typeof(MarketEntriesOutputDTO))]
    public class MarketEntriesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MarketEntriesArrayIndexFunction : MarketEntriesArrayIndexFunctionBase { }

    [Function("marketEntriesArrayIndex", "uint256")]
    public class MarketEntriesArrayIndexFunctionBase : FunctionMessage
    {

    }

    public partial class MarketEntriesTotalFunction : MarketEntriesTotalFunctionBase { }

    [Function("marketEntriesTotal", "uint256")]
    public class MarketEntriesTotalFunctionBase : FunctionMessage
    {

    }

    public partial class MarketEntryCreatedEventDTO : MarketEntryCreatedEventDTOBase { }

    [Event("MarketEntryCreated")]
    public class MarketEntryCreatedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "systemId", 1, true )]
        public virtual byte[] SystemId { get; set; }
        [Parameter("bytes32", "rawMaterial", 2, true )]
        public virtual byte[] RawMaterial { get; set; }
        [Parameter("tuple", "marketEntry", 3, false )]
        public virtual MarketEntry MarketEntry { get; set; }
    }

    public partial class MarketEntryMatchedEventDTO : MarketEntryMatchedEventDTOBase { }

    [Event("MarketEntryMatched")]
    public class MarketEntryMatchedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "systemId", 1, true )]
        public virtual byte[] SystemId { get; set; }
        [Parameter("tuple", "marketEntry", 2, false )]
        public virtual MarketEntry MarketEntry { get; set; }
    }

    public partial class MAX_ENTRIESOutputDTO : MAX_ENTRIESOutputDTOBase { }

    [FunctionOutput]
    public class MAX_ENTRIESOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint16", "", 1)]
        public virtual ushort ReturnValue1 { get; set; }
    }



    public partial class MarketEntriesOutputDTO : MarketEntriesOutputDTOBase { }

    [FunctionOutput]
    public class MarketEntriesOutputDTOBase : IFunctionOutputDTO 
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

    public partial class MarketEntriesArrayIndexOutputDTO : MarketEntriesArrayIndexOutputDTOBase { }

    [FunctionOutput]
    public class MarketEntriesArrayIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MarketEntriesTotalOutputDTO : MarketEntriesTotalOutputDTOBase { }

    [FunctionOutput]
    public class MarketEntriesTotalOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}

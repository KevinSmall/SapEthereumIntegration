using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SapEthereumIntegration.Contracts.RawMaterialMarket.ContractDefinition;

namespace SapEthereumIntegration.Contracts.RawMaterialMarket
{
    public partial class RawMaterialMarketService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, RawMaterialMarketDeployment rawMaterialMarketDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RawMaterialMarketDeployment>().SendRequestAndWaitForReceiptAsync(rawMaterialMarketDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, RawMaterialMarketDeployment rawMaterialMarketDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RawMaterialMarketDeployment>().SendRequestAsync(rawMaterialMarketDeployment);
        }

        public static async Task<RawMaterialMarketService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, RawMaterialMarketDeployment rawMaterialMarketDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, rawMaterialMarketDeployment, cancellationTokenSource);
            return new RawMaterialMarketService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public RawMaterialMarketService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<ushort> MAX_ENTRIESQueryAsync(MAX_ENTRIESFunction mAX_ENTRIESFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MAX_ENTRIESFunction, ushort>(mAX_ENTRIESFunction, blockParameter);
        }

        
        public Task<ushort> MAX_ENTRIESQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MAX_ENTRIESFunction, ushort>(null, blockParameter);
        }

        public Task<string> CreateBuyOfferRequestAsync(CreateBuyOfferFunction createBuyOfferFunction)
        {
             return ContractHandler.SendRequestAsync(createBuyOfferFunction);
        }

        public Task<TransactionReceipt> CreateBuyOfferRequestAndWaitForReceiptAsync(CreateBuyOfferFunction createBuyOfferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createBuyOfferFunction, cancellationToken);
        }

        public Task<string> CreateBuyOfferRequestAsync(byte[] systemId, byte[] rawMaterial, BigInteger kilos, BigInteger usdPerKilo)
        {
            var createBuyOfferFunction = new CreateBuyOfferFunction();
                createBuyOfferFunction.SystemId = systemId;
                createBuyOfferFunction.RawMaterial = rawMaterial;
                createBuyOfferFunction.Kilos = kilos;
                createBuyOfferFunction.UsdPerKilo = usdPerKilo;
            
             return ContractHandler.SendRequestAsync(createBuyOfferFunction);
        }

        public Task<TransactionReceipt> CreateBuyOfferRequestAndWaitForReceiptAsync(byte[] systemId, byte[] rawMaterial, BigInteger kilos, BigInteger usdPerKilo, CancellationTokenSource cancellationToken = null)
        {
            var createBuyOfferFunction = new CreateBuyOfferFunction();
                createBuyOfferFunction.SystemId = systemId;
                createBuyOfferFunction.RawMaterial = rawMaterial;
                createBuyOfferFunction.Kilos = kilos;
                createBuyOfferFunction.UsdPerKilo = usdPerKilo;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createBuyOfferFunction, cancellationToken);
        }

        public Task<MarketEntriesOutputDTO> MarketEntriesQueryAsync(MarketEntriesFunction marketEntriesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<MarketEntriesFunction, MarketEntriesOutputDTO>(marketEntriesFunction, blockParameter);
        }

        public Task<MarketEntriesOutputDTO> MarketEntriesQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var marketEntriesFunction = new MarketEntriesFunction();
                marketEntriesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<MarketEntriesFunction, MarketEntriesOutputDTO>(marketEntriesFunction, blockParameter);
        }

        public Task<BigInteger> MarketEntriesArrayIndexQueryAsync(MarketEntriesArrayIndexFunction marketEntriesArrayIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MarketEntriesArrayIndexFunction, BigInteger>(marketEntriesArrayIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> MarketEntriesArrayIndexQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MarketEntriesArrayIndexFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MarketEntriesTotalQueryAsync(MarketEntriesTotalFunction marketEntriesTotalFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MarketEntriesTotalFunction, BigInteger>(marketEntriesTotalFunction, blockParameter);
        }

        
        public Task<BigInteger> MarketEntriesTotalQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MarketEntriesTotalFunction, BigInteger>(null, blockParameter);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using PriceOracle.Api;
using SapEthereumIntegration.Api.Models;
using SapEthereumIntegration.Contracts.RawMaterialMarket;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace SapEthereumIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private const string ETHEREUM_URL = "https://rinkeby.infura.io/v3/1390b6c19faa4045af1a2b144f71084d";
        private const string MARKET_CONTRACT_ADDRESS = "0x9d7b4733abCa29e86956c82B09d9191d899dA032";
        private const string DEFAULT_SYS_ID = "ALL";

        // GET: api/market
        // Lists all market entries
        // GET: api/market?systemId=SomeSystemId (optional)
        // Lists all market entries for specified systemId
        [HttpGet]
        public async Task<IEnumerable<MarketEntryDisplayModel>> Get(string systemId = DEFAULT_SYS_ID)
        {
            Web3 web3 = new Web3(ETHEREUM_URL);
            var marketService = new RawMaterialMarketService(web3, MARKET_CONTRACT_ADDRESS);
            uint count = (uint)await marketService.MarketEntriesArrayIndexQueryAsync();

            // get individual market entries
            List<MarketEntryDisplayModel> allMarketEntries = new List<MarketEntryDisplayModel>();
            for (int i = 0; i < count; i++)
            {
                var me = await marketService.MarketEntriesQueryAsync(i);
                if (systemId == DEFAULT_SYS_ID || systemId == me.SystemId)
                {
                    allMarketEntries.Add(new MarketEntryDisplayModel()
                    {
                        SystemId = me.SystemId,
                        RawMaterial = me.RawMaterial,
                        Kilos = FormatBigInt(me.Kilos),
                        UsdPerKilo = FormatBigInt(me.UsdPerKilo),
                        Status = me.Status,
                        SellerContactEmail = me.SellerContactEmail
                    });
                }
            }
            return allMarketEntries.ToArray();
        }

        // POST api/market 
        [HttpPost]
        public async Task<ActionResult<MarketEntryDisplayModel>> Post([FromBody] MarketEntryCreateModel marketEntryCreateModel)
        {
            // Could add data validation here, check for empty strings etc, but smart contract does it anyway

            // Prepare transaction
            Account account = new Account("YOU NEED TO ENTER ACCOUNT PRIVATE KEY HERE");
            Web3 web3 = new Web3(account, ETHEREUM_URL);
            var marketService = new RawMaterialMarketService(web3, MARKET_CONTRACT_ADDRESS);
            byte[] systemIdBytes = marketEntryCreateModel.SystemId.ConvertToBytes();
            byte[] rawMaterialBytes = marketEntryCreateModel.RawMaterial.ConvertToBytes();

            // Send the transaction
            TransactionReceipt receipt = null;
            try
            {
                receipt = await marketService.CreateBuyOfferRequestAndWaitForReceiptAsync(
                    systemIdBytes,
                    rawMaterialBytes,
                    marketEntryCreateModel.Kilos,
                    marketEntryCreateModel.UsdPerKilo
                    );
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Internal error transaction sending failed with message: {ex.Message}");
            }

            // Get results
            var txStatus = receipt.Status.Value;
            if (txStatus == 1)
            {
                // get the most recently created record
                uint mostRecentEntryIndex = ((uint)await marketService.MarketEntriesArrayIndexQueryAsync()) - 1;
                var me = await marketService.MarketEntriesQueryAsync(mostRecentEntryIndex);
                return this.StatusCode(StatusCodes.Status201Created, new MarketEntryDisplayModel()
                {
                    SystemId = me.SystemId,
                    RawMaterial = me.RawMaterial,
                    Kilos = FormatBigInt(me.Kilos),
                    UsdPerKilo = FormatBigInt(me.UsdPerKilo),
                    Status = me.Status,
                    SellerContactEmail = me.SellerContactEmail
                });
            }
            else
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Internal error transaction sent but failed to process");
            }
        }

        private string FormatBigInt(BigInteger bi)
        {
            Decimal d = (decimal)bi;
            return d.ToString("0");
        }
    }
}

// SPDX-License-Identifier: MIT
pragma solidity 0.6.9;
pragma experimental ABIEncoderV2;

/// @title Raw Material Market
contract RawMaterialMarket
{
    uint16 public constant MAX_ENTRIES = 64;
    struct MarketEntry
    {
        bytes32 systemId;
        bytes32 rawMaterial;
        uint kilos;
        uint usdPerKilo;
        bytes32 status;
        bytes32 sellerContactEmail;
    }
    
    // For purposes of demo, market entries are a fixed-sized array that reuses/overwrites earlier entries
    // marketEntriesTotal holds total, but only the most recent MAX_ENTRIES are held in the array
    MarketEntry[MAX_ENTRIES] public marketEntries;
    uint public marketEntriesTotal;
    uint public marketEntriesArrayIndex;
    
    event MarketEntryCreated(bytes32 indexed systemId, bytes32 indexed rawMaterial, MarketEntry marketEntry);
    event MarketEntryMatched(bytes32 indexed systemId, MarketEntry marketEntry);
    
    function createBuyOffer(bytes32 systemId, bytes32 rawMaterial, uint kilos, uint usdPerKilo) public
    {
        // Validations
        require(systemId.length > 0, "System Id must be specified");
        require(rawMaterial.length > 0, "Raw Material must be specified");
        require(kilos > 0, "Kilos must be specified");
        require(usdPerKilo > 0, "USD per Kilo must be specified");
        
        // Prepare new buy offer market entry
        MarketEntry memory marketEntry;
        marketEntry.systemId = systemId;
        marketEntry.rawMaterial = rawMaterial;
        marketEntry.kilos = kilos;
        marketEntry.usdPerKilo = usdPerKilo;
        marketEntry.status = stringToBytes32("NEW");
        marketEntry.sellerContactEmail = stringToBytes32("EMPTY");
        
        // Store new buy offer market entry
        marketEntries[marketEntriesArrayIndex] = marketEntry;
        emit MarketEntryCreated(marketEntry.systemId, marketEntry.rawMaterial, marketEntry);
        
        // For purposes of demo, instant match all new buy offers with a pretend seller
        marketEntry.status = stringToBytes32("MATCHED");
        marketEntry.sellerContactEmail = stringToBytes32("cob@lt");
        marketEntries[marketEntriesArrayIndex] = marketEntry;
        emit MarketEntryMatched(marketEntry.systemId, marketEntry);
    
        // Overwrite earlier entries when array is full
        marketEntriesArrayIndex++;
        marketEntriesTotal++;
        if (marketEntriesArrayIndex >= MAX_ENTRIES)
        {
            marketEntriesArrayIndex = 0;
        }
    }
    
    
    /// @dev Set truncateToLength to <= 0 to take max bytes available
    function bytes32ToString(bytes32 x, uint truncateToLength) private pure returns (string memory) 
    {
        bytes memory bytesString = new bytes(32);
        uint charCount = 0;
        
        for (uint j = 0; j < 32; j++) 
        {
            byte char = byte(bytes32(uint(x) * 2 ** (8 * j)));
            if (char != 0) 
            {
                bytesString[charCount] = char;
                charCount++;
            }
        }
        
        uint finalLength = 0;
        if (truncateToLength > charCount || truncateToLength <= 0)
        {
            finalLength = charCount;
        }
        else
        {
            finalLength = truncateToLength - 1;
        }
        
        bytes memory bytesStringTrimmed = new bytes(finalLength);
        for (uint j = 0; j < finalLength; j++) 
        {
            bytesStringTrimmed[j] = bytesString[j];
        }
        return string(bytesStringTrimmed);
    }
    
    /// @dev Pads shorter strings with 0, truncates longer strings to length 32
    function stringToBytes32(string memory source) private pure returns (bytes32 result) 
    {
        bytes memory tempEmptyStringTest = bytes(source);
        if (tempEmptyStringTest.length == 0) 
        {
            return 0x0;
        }

        assembly
        {
            result := mload(add(source, 32))
        }
    }
}
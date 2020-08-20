using Nethereum.ABI;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using Nethereum.ABI.Decoders;
using Nethereum.ABI.Encoders;

namespace PriceOracle.Api
{
    public static class ExtensionMethods
    {
        private static Bytes32TypeEncoder _encoder;
        private static StringBytes32Decoder _decoder;

        static ExtensionMethods()
        {
            _encoder = new Bytes32TypeEncoder();
            _decoder = new StringBytes32Decoder();

        }

        public static byte[] ConvertToBytes(this string s)
        {
            if (s == null) return null;
            return _encoder.Encode(s);
        }

        public static string ConvertToString(this byte[] b)
        {
            if (b == null) return null;
            return _decoder.Decode(b);
        }

        public static string HexToUpper(this string s)
        {
            if (s.Substring(0, 2) == "0x")
            {
                string rhs = s.Substring(2);
                string rhsu = rhs.ToUpperInvariant();
                return "0x" + rhsu;
            }
            else
            {
                return s;
            }
        }

        public static string HexToLower(this string s)
        {
            if (s.Substring(0, 2) == "0x")
            {
                string rhs = s.Substring(2);
                string rhsu = rhs.ToLowerInvariant();
                return "0x" + rhsu;
            }
            else
            {
                return s;
            }
        }
    }
}

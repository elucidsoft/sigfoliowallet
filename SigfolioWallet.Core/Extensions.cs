using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigfolioWallet.Core
{
    public static class Extensions
    {
        public static string ToStringHex(this byte[] bytes)
        {
            var hex = BitConverter
                .ToString(bytes)
                .Replace("-", "")
                .ToLower();

            return hex;
        }

        public static byte[] HexToByteArray(this string hex)
        {
            var bytes = Enumerable.Range(0, hex.Length / 2)
                .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                .ToArray();

            return bytes;
        }
    }
}

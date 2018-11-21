using System;
using System.Collections.Generic;
using System.Text;

namespace SigfolioWallet.Core.Utilities
{
    public class StellarSDKExtensions
    {
        public static string ShortAddress(string address, int charactersAtStart = 5, int charactersAtEnd = 4, string separator = "...")
        {
            return string.Concat(address.Substring(0, charactersAtStart), separator, address.Substring(address.Length - charactersAtEnd, charactersAtEnd));
        }
    }
}

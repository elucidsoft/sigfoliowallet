using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigfolioWallet.Core.Services;

namespace SigfolioWallet.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IStellarHorizonService service = new StellarHorizonService("");

            var accounts = service.Server.Accounts;
        }
    }
}

using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Tests;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.UWP;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace SigfolioWallet.UWP.Test
{
    [TestClass]
    public class UnitTest1 : MvxIoCSupportingTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Setup();
        }

        //protected override void AdditionalSetup()
        //{
        //    Ioc.RegisterSingleton(new SettingsService());
        //}

        //[TestMethod]
        //public async Task TestSettingsProtectAndUnprotect()
        //{
        //    var myApplicationDataContainer = new FakeApplicationDataContainer();
        //    var localSettings = new SettingsService((ApplicationDataContainer)myApplicationDataContainer);

        //    var wallet = new Wallet { WalletName = "test wallet" };
        //    wallet.Accounts.Add(new Account()
        //    {
        //        Name = "test1",
        //        PublicKey = "2153245224365265246236gasgasg"
        //    });

        //    await localSettings.SaveWallet(wallet);

        //    var encryptedWalletString = myApplicationDataContainer.Values["wallet"].ToString();
        //    Assert.IsFalse(encryptedWalletString.Contains("test"));

        //    var savedWallet = await localSettings.LoadWallet();

        //    Assert.AreEqual(wallet, savedWallet);
        //}
    }

    public class FakeApplicationDataContainer
    {
        public FakeApplicationDataContainer()
        {
            Values = new PropertySet();
        }

        public IPropertySet Values { get; set; }

        public static explicit operator ApplicationDataContainer(FakeApplicationDataContainer myAppDataContainer)
        {
            var appDataContainer = ApplicationData.Current.LocalSettings;

            myAppDataContainer.Values = appDataContainer.Values;

            return appDataContainer;
        }
    }


}

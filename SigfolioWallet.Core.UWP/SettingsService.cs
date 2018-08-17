using System;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage;
using Windows.Storage.Streams;
using Newtonsoft.Json;
using SigfolioWallet.Core.Models;
using SigfolioWallet.Core.Services;

namespace SigfolioWallet.Core.UWP
{
    /// <summary>
    /// This is for insecure Settings only, we are still going to store these in Protected Storage but private keys do not go into this
    /// settings file. That is handled by the SecureSettingsService only.
    /// </summary>
    public class SettingsService : ISettingsService
    {
        private const string WalletSettingsContainerKey = "wallet_settings";

        private readonly DataProtectionProvider _provider = new DataProtectionProvider("LOCAL = user");
        readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        private readonly ApplicationDataContainer _walletContainer;

        public SettingsService()
        {
            _walletContainer = _localSettings.CreateContainer(WalletSettingsContainerKey, ApplicationDataCreateDisposition.Always);
        }

        public SettingsService(ApplicationDataContainer applicationDataContainer)
        {
            _walletContainer = applicationDataContainer;
        }

        public async Task<Wallet> GetCurrentWallet()
        {
            if(!_walletContainer.Values.ContainsKey("wallet"))
                return await Task.FromResult(new Wallet());

            IBuffer buffer = CryptographicBuffer.DecodeFromBase64String((string)_walletContainer.Values["wallet"]);
            var jsonBuffer = await _provider.UnprotectAsync(buffer);

            return JsonConvert.DeserializeObject<Wallet>(CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, jsonBuffer));
        }

        public async Task SaveWallet(Wallet wallet)
        {
            var buffer = CryptographicBuffer.ConvertStringToBinary(JsonConvert.SerializeObject(wallet), BinaryStringEncoding.Utf8);
            string encrypted = CryptographicBuffer.EncodeToBase64String(await _provider.ProtectAsync(buffer));

            _walletContainer.Values["wallet"] = encrypted;
        }
    }
}
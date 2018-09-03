using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using LiteDB;
using Newtonsoft.Json;

namespace SigfolioWallet.Core.Models
{
    public class EncryptionKeys
    {
        public EncryptionKeys() { }

        public EncryptionKeys(byte[] salt, byte[] iv)
        {
            SaltBytes = salt;
            IvBytes = iv;
        }

        public string Iv
        {
            get => IvBytes.ToStringHex();
            set => IvBytes = value.HexToByteArray();
        }

        public string Salt
        {
            get => SaltBytes.ToStringHex();
            set => SaltBytes = value.HexToByteArray();
        }

        [BsonIgnore]
        public byte[] SaltBytes { get; private set; }

        [BsonIgnore]
        public byte[] IvBytes { get; private set; }
    }
}

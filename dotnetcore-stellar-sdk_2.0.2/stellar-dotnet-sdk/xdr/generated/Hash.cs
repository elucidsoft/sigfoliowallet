// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================

//  typedef opaque Hash[32];

//  ===========================================================================
    public class Hash
    {
        public Hash()
        {
        }

        public Hash(byte[] value)
        {
            InnerValue = value;
        }

        public byte[] InnerValue { get; set; } = default(byte[]);

        public static void Encode(XdrDataOutputStream stream, Hash encodedHash)
        {
            var Hashsize = encodedHash.InnerValue.Length;
            stream.Write(encodedHash.InnerValue, 0, Hashsize);
        }

        public static Hash Decode(XdrDataInputStream stream)
        {
            var decodedHash = new Hash();
            var Hashsize = 32;
            decodedHash.InnerValue = new byte[Hashsize];
            stream.Read(decodedHash.InnerValue, 0, Hashsize);
            return decodedHash;
        }
    }
}
// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================

//  struct DecoratedSignature
//  {
//      SignatureHint hint;  // last 4 bytes of the public key, used as a hint
//      Signature signature; // actual signature
//  };

//  ===========================================================================
    public class DecoratedSignature
    {
        public SignatureHint Hint { get; set; }
        public Signature Signature { get; set; }

        public static void Encode(XdrDataOutputStream stream, DecoratedSignature encodedDecoratedSignature)
        {
            SignatureHint.Encode(stream, encodedDecoratedSignature.Hint);
            Signature.Encode(stream, encodedDecoratedSignature.Signature);
        }

        public static DecoratedSignature Decode(XdrDataInputStream stream)
        {
            var decodedDecoratedSignature = new DecoratedSignature();
            decodedDecoratedSignature.Hint = SignatureHint.Decode(stream);
            decodedDecoratedSignature.Signature = Signature.Decode(stream);
            return decodedDecoratedSignature;
        }
    }
}
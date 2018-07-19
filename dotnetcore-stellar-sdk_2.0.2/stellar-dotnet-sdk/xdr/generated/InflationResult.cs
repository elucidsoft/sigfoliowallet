// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================

//  union InflationResult switch (InflationResultCode code)
//  {
//  case INFLATION_SUCCESS:
//      InflationPayout payouts<>;
//  default:
//      void;
//  };

//  ===========================================================================
    public class InflationResult
    {
        public InflationResultCode Discriminant { get; set; } = new InflationResultCode();

        public InflationPayout[] Payouts { get; set; }

        public static void Encode(XdrDataOutputStream stream, InflationResult encodedInflationResult)
        {
            stream.WriteInt((int) encodedInflationResult.Discriminant.InnerValue);
            switch (encodedInflationResult.Discriminant.InnerValue)
            {
                case InflationResultCode.InflationResultCodeEnum.INFLATION_SUCCESS:
                    var payoutssize = encodedInflationResult.Payouts.Length;
                    stream.WriteInt(payoutssize);
                    for (var i = 0; i < payoutssize; i++) InflationPayout.Encode(stream, encodedInflationResult.Payouts[i]);
                    break;
                default:
                    break;
            }
        }

        public static InflationResult Decode(XdrDataInputStream stream)
        {
            var decodedInflationResult = new InflationResult();
            var discriminant = InflationResultCode.Decode(stream);
            decodedInflationResult.Discriminant = discriminant;
            switch (decodedInflationResult.Discriminant.InnerValue)
            {
                case InflationResultCode.InflationResultCodeEnum.INFLATION_SUCCESS:
                    var payoutssize = stream.ReadInt();
                    decodedInflationResult.Payouts = new InflationPayout[payoutssize];
                    for (var i = 0; i < payoutssize; i++) decodedInflationResult.Payouts[i] = InflationPayout.Decode(stream);
                    break;
                default:
                    break;
            }
            return decodedInflationResult;
        }
    }
}
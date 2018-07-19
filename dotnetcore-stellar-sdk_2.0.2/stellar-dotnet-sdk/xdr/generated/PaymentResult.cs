// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================

//  union PaymentResult switch (PaymentResultCode code)
//  {
//  case PAYMENT_SUCCESS:
//      void;
//  default:
//      void;
//  };

//  ===========================================================================
    public class PaymentResult
    {
        public PaymentResultCode Discriminant { get; set; } = new PaymentResultCode();

        public static void Encode(XdrDataOutputStream stream, PaymentResult encodedPaymentResult)
        {
            stream.WriteInt((int) encodedPaymentResult.Discriminant.InnerValue);
            switch (encodedPaymentResult.Discriminant.InnerValue)
            {
                case PaymentResultCode.PaymentResultCodeEnum.PAYMENT_SUCCESS:
                    break;
                default:
                    break;
            }
        }

        public static PaymentResult Decode(XdrDataInputStream stream)
        {
            var decodedPaymentResult = new PaymentResult();
            var discriminant = PaymentResultCode.Decode(stream);
            decodedPaymentResult.Discriminant = discriminant;
            switch (decodedPaymentResult.Discriminant.InnerValue)
            {
                case PaymentResultCode.PaymentResultCodeEnum.PAYMENT_SUCCESS:
                    break;
                default:
                    break;
            }
            return decodedPaymentResult;
        }
    }
}
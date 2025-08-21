using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.Payment
{
    public class SchemeMapper : ISchemeMapper
    {
        private readonly Dictionary<PaymentScheme, AllowedPaymentSchemes> _schemes;
        public SchemeMapper(Dictionary<PaymentScheme, AllowedPaymentSchemes>? schemes = null)
        {
            _schemes = schemes ?? new Dictionary<PaymentScheme, AllowedPaymentSchemes>
            {
                { PaymentScheme.Bacs, AllowedPaymentSchemes.Bacs },
                { PaymentScheme.FasterPayments, AllowedPaymentSchemes.FasterPayments },
                { PaymentScheme.Chaps, AllowedPaymentSchemes.Chaps },
            };
        }

        public AllowedPaymentSchemes MapAllowedScheme(PaymentScheme scheme)
        {
            return this._schemes.GetValueOrDefault(scheme, AllowedPaymentSchemes.Bacs);
        }
    }
}

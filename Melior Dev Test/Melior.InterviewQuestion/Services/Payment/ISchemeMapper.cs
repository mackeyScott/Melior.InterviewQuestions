using Melior.InterviewQuestion.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.Payment
{
    public interface ISchemeMapper
    {
        AllowedPaymentSchemes MapAllowedScheme(PaymentScheme scheme);
    }
}

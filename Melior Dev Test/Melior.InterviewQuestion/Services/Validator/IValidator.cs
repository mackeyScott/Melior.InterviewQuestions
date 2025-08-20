using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.Validator
{
    public interface IValidator
    {
        bool CanMakePayment(Types.Account account, decimal amount, AllowedPaymentSchemes scheme);
    }
}

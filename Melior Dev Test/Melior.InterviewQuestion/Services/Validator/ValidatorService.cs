using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.Services.Validator
{
    public class ValidatorService : IValidator
    {
        public ValidatorService() { }

        private bool IsAccountLive(Types.Account account)
        {
            return account.Status switch
            {
                AccountStatus.Live => true,
                AccountStatus.InboundPaymentsOnly => true,
                AccountStatus.Disabled => false,
                _ => false
            };
        }

        public bool CanMakePayment(Types.Account account, decimal amount, AllowedPaymentSchemes scheme)
        {
            if (IsAccountLive(account) && account.AllowedPaymentSchemes.HasFlag(scheme))
            {
                return account.Balance >= amount;
            }
            return false;
        }
    }
}

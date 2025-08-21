using Melior.InterviewQuestion.Services.Account;
using Melior.InterviewQuestion.Services.Validator;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private IAccountService accountService;
        private IValidator validator;
        private ISchemeMapper schemeMapper;
        public PaymentService(IAccountService accountService, IValidator validator, ISchemeMapper schemeMapper)
        {
            this.accountService = accountService;
            this.validator = validator;
            this.schemeMapper = schemeMapper;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Types.Account account = this.accountService.GetAccount(request.DebtorAccountNumber);

            var result = new MakePaymentResult();
            result.Success = ProcessPayment(account, request);

            if (result.Success)
            {
                account.Balance -= request.Amount;
                this.accountService.UpdateAccount(account);
            }

            return result;
        }

        public bool ProcessPayment(Types.Account account, MakePaymentRequest request)
        {
            return this.validator.CanMakePayment(account, request.Amount, this.schemeMapper.MapAllowedScheme(request.PaymentScheme));
        }
    }
}

using Melior.InterviewQuestion.Services.Validator;
using Melior.InterviewQuestion.Types;
using Melior.InterviewQuestion.UnitTesting.MemberData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.UnitTesting
{
    public class ValidatorService : IDisposable
    {
        public Services.Validator.ValidatorService validator;
        public ValidatorService()
        {
            this.validator = new Services.Validator.ValidatorService();
        }
        public void Dispose(){}

        [Theory]
        [MemberData(nameof(TestDataRepo.correctBacAccts), MemberType = typeof(TestDataRepo))]
        [MemberData(nameof(TestDataRepo.correctChapAccts), MemberType = typeof(TestDataRepo))]
        [MemberData(nameof(TestDataRepo.correctFasterAccts), MemberType = typeof(TestDataRepo))]
        public void ItCanMakePayment(List<Account> accounts, MakePaymentRequest request)
        {
            foreach (Account account in accounts)
            {
                Assert.True(this.validator.CanMakePayment(account, request.Amount,
                    request.PaymentScheme switch 
                    { 
                        PaymentScheme.Bacs => AllowedPaymentSchemes.Bacs,
                        PaymentScheme.FasterPayments => AllowedPaymentSchemes.FasterPayments,
                        PaymentScheme.Chaps => AllowedPaymentSchemes.Chaps
                    }));
            }
        }

        [Theory]
        [MemberData(nameof(TestDataRepo.incorrectAccounts), MemberType = typeof(TestDataRepo))]
        public void ItCantMakePayment(List<Account> accounts, MakePaymentRequest request)
        {
            foreach (Account account in accounts)
            {
                Assert.False(this.validator.CanMakePayment(account, request.Amount,
                    request.PaymentScheme switch
                    {
                        PaymentScheme.Bacs => AllowedPaymentSchemes.Bacs,
                        PaymentScheme.FasterPayments => AllowedPaymentSchemes.FasterPayments,
                        PaymentScheme.Chaps => AllowedPaymentSchemes.Chaps
                    }));
            }

        }
    }
}

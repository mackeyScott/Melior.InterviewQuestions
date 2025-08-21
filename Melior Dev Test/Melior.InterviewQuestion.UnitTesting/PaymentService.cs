using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using Melior.InterviewQuestion.UnitTesting.MemberData;
using Moq;


namespace Melior.InterviewQuestion.UnitTesting
{
    public class PaymentService : IDisposable
    {
        public Services.Account.AccountService accountService { get; set; }
        public Services.Configuration.AppConfigService appConfigService { get; set; }
        public Services.Validator.ValidatorService validator { get; set; }
        public Services.Payment.PaymentService paymentService { get; set; }
        public Services.Payment.SchemeMapper paymentSchemeMapper { get; set; }

        public PaymentService()
        {
            var mockAccountStore = new Mock<IAccountsDataStore>();
            mockAccountStore.Setup(x => x.GetAccount(It.IsAny<string>()))
                .Returns(new Account
                {
                    AccountNumber = "123434",
                    AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                    Balance = 4534,
                    Status = AccountStatus.Live
                });
            this.validator = new Services.Validator.ValidatorService();
            this.appConfigService = new Services.Configuration.AppConfigService();
            this.paymentSchemeMapper = new Services.Payment.SchemeMapper();
            this.accountService = new Services.Account.AccountService(this.appConfigService);
            this.accountService.accountsDataStore = mockAccountStore.Object;
            this.paymentService = new Services.Payment.PaymentService(this.accountService, this.validator, this.paymentSchemeMapper);
        }

        public void Dispose(){}

        [Theory]
        [MemberData(nameof(TestDataRepo.correctBacAccts), MemberType = typeof(TestDataRepo))]
        [MemberData(nameof(TestDataRepo.correctChapAccts), MemberType = typeof(TestDataRepo))]
        [MemberData(nameof(TestDataRepo.correctFasterAccts), MemberType = typeof(TestDataRepo))]
        public void ItWillProcessPayments(List<Account> accounts, MakePaymentRequest request)
        {
            foreach(Account account in accounts)
            {
                Assert.True(this.paymentService.ProcessPayment(account, request));
            }
        }

        [Theory]
        [MemberData(nameof(TestDataRepo.incorrectAccounts), MemberType = typeof(TestDataRepo))]
        public void ItWillFailPayments(List<Account> accounts, MakePaymentRequest request)
        {
            foreach (Account account in accounts)
            {
                Assert.False(this.paymentService.ProcessPayment(account, request));
            }
        }

        [Theory]
        [MemberData(nameof(TestDataRepo.correctPayments), MemberType = typeof(TestDataRepo))]
        public void ItWillMakeProcessPayments(List<MakePaymentRequest> request)
        {
            foreach (MakePaymentRequest test in request)
            {
                Assert.True(this.paymentService.MakePayment(test).Success);
            }

        }

        [Theory]
        [MemberData(nameof(TestDataRepo.incorrectPayments), MemberType = typeof(TestDataRepo))]
        public void ItWillFailMakePayments(List<MakePaymentRequest> request)
        {
            foreach(MakePaymentRequest test in request)
            {
                Assert.False(this.paymentService.MakePayment(test).Success);
            }
        }
    }
}
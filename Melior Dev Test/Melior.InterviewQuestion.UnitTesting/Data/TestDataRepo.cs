using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.UnitTesting.MemberData
{
    public static class TestDataRepo
    {

        public static IEnumerable<object[]> correctBacAccts = new List<object[]> {

            new object[] {new List<Account>()
            {
                new Account()
                {
                    AccountNumber = "123456",
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                    Balance = 1000,
                    Status = AccountStatus.Live
                },
                new Account()
                {
                    AccountNumber = "67890",
                    AllowedPaymentSchemes= AllowedPaymentSchemes.Bacs,
                    Balance = 11231,
                    Status = AccountStatus.Live
                },
                new Account()
                {
                    AccountNumber = "246810",
                    AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                    Balance = 75893,
                    Status = AccountStatus.Live
                }
            },
            new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.Bacs,
                Amount = 100,
                CreditorAccountNumber = "012345",
                DebtorAccountNumber= "1234567890",
                PaymentDate= DateTime.Now
            } }
        };

        public static IEnumerable<object[]> correctChapAccts = new List<object[]>
        {
            new object[] {
                new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = "123456",
                        AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                        Balance = 1000,
                        Status = AccountStatus.Live
                    },
                    new Account()
                    {
                        AccountNumber = "67890",
                        AllowedPaymentSchemes= AllowedPaymentSchemes.Chaps,
                        Balance = 5439,
                        Status = AccountStatus.Live
                    },
                    new Account()
                    {
                        AccountNumber = "246810",
                        AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                        Balance = 12314,
                        Status = AccountStatus.Live
                    }
                },
                new MakePaymentRequest()
                {
                    PaymentScheme = PaymentScheme.Chaps,
                    Amount = 100,
                    CreditorAccountNumber = "012345",
                    DebtorAccountNumber= "1234567890",
                    PaymentDate= DateTime.Now
                }
            }
        };

        public static IEnumerable<object[]> correctFasterAccts = new List<object[]>
        {
            new object[] {
                new List<Account>()
                {
                    new Account()
                    {
                        AccountNumber = "15616518",
                        AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                        Balance = 981981,
                        Status = AccountStatus.Live
                    },
                    new Account()
                    {
                        AccountNumber = "161562",
                        AllowedPaymentSchemes= AllowedPaymentSchemes.FasterPayments,
                        Balance = 128981,
                        Status = AccountStatus.Live
                    },
                    new Account()
                    {
                        AccountNumber = "651561",
                        AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                        Balance = 65155,
                        Status = AccountStatus.Live
                    }
                },
                new MakePaymentRequest()
                {
                    PaymentScheme = PaymentScheme.FasterPayments,
                    Amount = 10005,
                    CreditorAccountNumber = "012345",
                    DebtorAccountNumber= "1234567890",
                    PaymentDate= DateTime.Now
                }
            }
        };

        public static IEnumerable<object[]> incorrectAccounts = new List<object[]>
        {
            new object[] {
                new List<Account>()
                {
                    new Account() {
                        AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                        Balance = -50,
                        Status = AccountStatus.Live,
                        AccountNumber = "1234567890"
                    },
                    new Account()
                    {
                        AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                        Balance = 1708,
                        Status = AccountStatus.Disabled,
                        AccountNumber = "4891981"
                    },
                    new Account()
                    {
                        AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                        Balance = (decimal)0.61,
                        Status = AccountStatus.InboundPaymentsOnly,
                        AccountNumber = "145349587"
                    }
                },
                new MakePaymentRequest()
                {
                    PaymentScheme = PaymentScheme.FasterPayments,
                    Amount = 10005,
                    CreditorAccountNumber = "012345",
                    DebtorAccountNumber= "1234567890",
                    PaymentDate= DateTime.Now
                }

            }
        };

        public static IEnumerable<object[]> correctPayments = new List<object[]>
        {
            new object[]
            {
                new List<MakePaymentRequest>(){
                    new MakePaymentRequest()
                    {
                        PaymentScheme = PaymentScheme.FasterPayments,
                        PaymentDate = DateTime.Now,
                        Amount = (decimal)342.32,
                        CreditorAccountNumber= "1234567890",
                        DebtorAccountNumber = "2342342"
                    },
                    new MakePaymentRequest()
                    {
                        PaymentScheme = PaymentScheme.FasterPayments,
                        PaymentDate = DateTime.Now,
                        Amount = (decimal)765.42,
                        CreditorAccountNumber= "123135797867",
                        DebtorAccountNumber = "4816"
                    },
                    new MakePaymentRequest()
                    {
                        PaymentScheme = PaymentScheme.FasterPayments,
                        PaymentDate = DateTime.Now,
                        Amount = (decimal)1634.10,
                        CreditorAccountNumber= "753221",
                        DebtorAccountNumber = "65644"
                    }
                }
            }

        };
        public static IEnumerable<object[]> incorrectPayments = new List<object[]>
        {
            new object[]
            {
                new List<MakePaymentRequest>(){
                    new MakePaymentRequest()
                    {
                        PaymentScheme = PaymentScheme.Bacs,
                        PaymentDate = DateTime.Now,
                        Amount = (decimal)342.32,
                        CreditorAccountNumber= "457823",
                        DebtorAccountNumber = "23423123142"
                    },
                    new MakePaymentRequest()
                    {
                        PaymentScheme = PaymentScheme.FasterPayments,
                        PaymentDate = DateTime.Now,
                        Amount = (decimal)1000000.01,
                        CreditorAccountNumber= "12345",
                        DebtorAccountNumber = "89865"
                    },
                    new MakePaymentRequest()
                    {
                        PaymentScheme = PaymentScheme.Chaps,
                        PaymentDate = DateTime.Now,
                        Amount = (decimal)-15,
                        CreditorAccountNumber= "2342",
                        DebtorAccountNumber = "5743"
                    }
                }
            }

        };
    }
}

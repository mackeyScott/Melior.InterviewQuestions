using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.UnitTesting
{
    public class AccountService : IDisposable
    {
        public Services.Account.AccountService accountService;
        public Services.Configuration.AppConfigService appConfigService;
        public AccountService()
        {
            this.appConfigService = new Services.Configuration.AppConfigService();
            this.accountService = new Services.Account.AccountService(this.appConfigService);
        }
        public void Dispose(){}

        [Theory]
        [InlineData("2547837")]
        [InlineData("3242734")]
        [InlineData("3224543")]
        public void ItWillGetAccounts(string accountNumber)
        {
            Assert.IsType<Account>(this.accountService.GetAccount(accountNumber));
        }

        [Theory]
        [InlineData(true)]
        public void ItWillReturnBackUpDataStore(bool value)
        {
            Assert.IsType<BackupAccountDataStore>(AccountsFactory.CreateAccountStore(value));
        }

        [Theory]
        [InlineData(false)]
        public void ItWontReturnBackUpDataStore(bool value)
        {
            Assert.IsNotType<BackupAccountDataStore>(AccountsFactory.CreateAccountStore(value));
        }
    }
}

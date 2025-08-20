using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Services.Configuration;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Account
{
    public class AccountService : IAccountService
    {
        private IAppConfigService appConfigService;
        public IAccountsDataStore accountsDataStore;
        public AccountService(IAppConfigService appConfigService)
        {
            this.appConfigService = appConfigService;
            this.accountsDataStore = AccountsFactory.CreateAccountStore(this.appConfigService.DataStoreIsBackup());
        }

        public Types.Account GetAccount(string accountNumber)
        {
            return this.accountsDataStore.GetAccount(accountNumber);
        }

        public void UpdateAccount(Types.Account account)
        {
            this.accountsDataStore.UpdateAccount(account);
        }

    }
}

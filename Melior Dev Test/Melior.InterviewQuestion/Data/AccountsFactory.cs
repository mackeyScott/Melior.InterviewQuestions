namespace Melior.InterviewQuestion.Data
{
    public static class AccountsFactory
    {
        public static IAccountsDataStore CreateAccountStore(bool backup)
        {
            return backup ? new BackupAccountDataStore() : new AccountDataStore();
        }
    }
}

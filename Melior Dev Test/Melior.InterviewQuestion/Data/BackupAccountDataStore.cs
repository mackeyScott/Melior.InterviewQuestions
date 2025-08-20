using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Data
{
    public class BackupAccountDataStore : IAccountsDataStore
    {
        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Access database to retrieve account, code removed for brevity
        }
    }
}

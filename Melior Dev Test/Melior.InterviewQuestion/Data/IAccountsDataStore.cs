using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Data
{
    public interface IAccountsDataStore
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);

    }
}

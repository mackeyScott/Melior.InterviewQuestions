using Melior.InterviewQuestion.Data;
using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Account
{
    public interface IAccountService
    {
        Types.Account GetAccount(string accountNumber);
        void UpdateAccount(Types.Account account);
    }
}

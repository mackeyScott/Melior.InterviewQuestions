using Melior.InterviewQuestion.Types;

namespace Melior.InterviewQuestion.Services.Payment
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
        bool ProcessPayment(Types.Account account, MakePaymentRequest request);
    }
}

using Melior.InterviewQuestion.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melior.InterviewQuestion.UnitTesting
{
    public class SchemeMapper : IDisposable
    {
        private Services.Payment.SchemeMapper service;
        public SchemeMapper() 
        {
            this.service = new Services.Payment.SchemeMapper();
        }

        public void Dispose() {}

        [Theory]
        [InlineData(PaymentScheme.FasterPayments)]
        [InlineData(PaymentScheme.Bacs)]
        [InlineData(PaymentScheme.Chaps)]
        public void ItWillMapSchemes(PaymentScheme scheme)
        {
            Assert.IsType<AllowedPaymentSchemes>(this.service.MapAllowedScheme(scheme));
        }
    }
}

using Program4.Entities.Interfaces;

namespace Program4.Entities.Services
{
    class PaypalService : IOnlinePaymentService
    {
        private double _feePercentage = 0.02;
        private double _monthlyInterest = 0.01;

        public double Interest(double amount, int months)
        {
            return _monthlyInterest * amount * months;
        }

        public double PaymentFee(double amount)
        {
            return _feePercentage * amount;
        }
    }
}

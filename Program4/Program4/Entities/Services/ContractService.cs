using Program4.Entities.Interfaces;

namespace Program4.Entities.Services
{
    class ContractService
    {
        private IOnlinePaymentService _service;
        
        public ContractService(IOnlinePaymentService service)
        {
            _service = service;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;

            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double quota = basicQuota + _service.Interest(basicQuota, i);
                quota += _service.PaymentFee(quota);

                contract.AddInstallment(new Installment(date, quota));
            }
        }
    }
}

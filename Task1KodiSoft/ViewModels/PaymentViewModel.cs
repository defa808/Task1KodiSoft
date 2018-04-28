using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1KodiSoft.ViewModels
{
    public class PaymentViewModel
    {
        public double OperationNumberCredit { get; set; }
        public double OperationNumberCash { get; set; }
        public double  AmountMoneyCredit { get; set; }
        public double  AmountMoneyCash { get; set; }

        public double TipsAverage { get; set; }
        public double TipsNumber { get; set; }
        public double TipsSum { get; set; }

    }
}

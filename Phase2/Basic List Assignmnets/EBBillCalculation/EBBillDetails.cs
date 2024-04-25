using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillCalculation
{
    public class EBBillDetails
    {
        public static int _meterId=1000;
        public string MeterId { get; set; }
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string MailId { get; set; }
        public int UnitsUsed { get; set; }
        public EBBillDetails(){
            _meterId++;
            MeterId="EB"+_meterId;

        }
        public int CalculateAmount(int unit){
            int amount=unit*5;
            return amount;

        }
    }
}
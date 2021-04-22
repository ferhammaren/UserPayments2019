using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPayments.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string concept { get; set; }
        public int userId { get; set; }

        public static Payment getPayment (int id)
        {
            Payment obj=new Payment();
            
            return obj;
        }

        public static bool EditPayment(int id, decimal Amount)
        {
            if (getPayment(id) != null)
            {
                Payment obj = getPayment(id);
                obj.Amount = Amount;
                obj.PaymentDate = DateTime.Now;

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeletePayment(int id, decimal Amount)
        {
            if (getPayment(id) != null)
            {
                Payment obj = getPayment(id);
               

                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

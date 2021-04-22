using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserPayments.Models
{
    public class PaymentTestContext
    {
        public string ConnectionString { get; set; }

        public PaymentTestContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Payment getPayment(int id)
        {
            Payment obj = new Payment();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GET_PAYMENT";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@paymentID",id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.PaymentId = id;
                        obj.PaymentDate = Convert.ToDateTime(reader["date"]);
                        obj.Amount = Convert.ToDecimal(reader["amount"]);
                        obj.concept = reader["concept"].ToString();
                    }
                }
            }
            return obj;
        }


        public List<Payment> getPayments(int id)
        {
            List<Payment> obj = new List<Payment>();
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "getUserPayments";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("userId", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Payment obj1 = new Payment();
                        obj1.PaymentId = id;
                        obj1.PaymentDate = Convert.ToDateTime(reader["date"]);
                        obj1.Amount = Convert.ToDecimal(reader["amount"]);
                        obj1.concept = reader["concept"].ToString();
                        obj.Add(obj1);
                    }
                }
            }
            return obj;
        }


    }
}

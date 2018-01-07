using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace TransactionScopeSamples
{
    /// <summary>
    /// Basic Sample
    /// </summary>
    public class Sample1
    {
        public void BasicTransaction()
        {             
            using (TransactionScope tsScope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(""))
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO ", con);
                    SqlCommand cmd2 = new SqlCommand("UPDTATE ", con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    //In Addition, We can add entityframework commands or others here 
                    //using (var context = new NorthwindContext(conn))
                    //{
                    //    var query = context.Orders.Where(x=>x.OrderId == 1000).FirstOrDefault();
                    //    query.Address = "Street, Avenue, No:15 etc.";                        
                    //    context.SaveChanges();
                    //}
                }
                tsScope.Complete();
                //if u want u can use to rollback => Transaction.Current.Rollback();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TransactionScopeSamples
{
    /// <summary>
    /// Set TransactionOption Details
    /// </summary>
    public class Sample4
    {
        public void SetTransactionDetails()
        {            
            TransactionOptions tran = new TransactionOptions();
            tran.IsolationLevel = System.Transactions.IsolationLevel.Chaos;
            tran.Timeout = new TimeSpan(0, 0, 50);

            using (TransactionScope tsScope = new TransactionScope(TransactionScopeOption.RequiresNew, tran))
            {
                using (SqlConnection conAdventureWorks = new SqlConnection("AdventureWorks Connection String"))
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO ", conAdventureWorks);
                    SqlCommand cmd2 = new SqlCommand("UPDTATE ", conAdventureWorks);
                    conAdventureWorks.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();                    
                }
                tsScope.Complete();
            }
        }
    }
}

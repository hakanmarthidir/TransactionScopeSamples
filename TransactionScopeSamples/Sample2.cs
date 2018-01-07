using System.Data.SqlClient;
using System.Transactions;

namespace TransactionScopeSamples
{
    /// <summary>
    /// Different Databases - DTC Sample
    /// </summary>
    public class Sample2
    {
        public void UseDifferentDatabases()
        {            
            using (TransactionScope tsScope = new TransactionScope())
            {             
                using (SqlConnection conAdventureWorks = new SqlConnection("AdventureWorks Connection String"))
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO ", conAdventureWorks);
                    SqlCommand cmd2 = new SqlCommand("UPDTATE ", conAdventureWorks);
                    conAdventureWorks.Open();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    
                    using (SqlConnection conNorthwind = new SqlConnection("Northwind Connection String"))
                    {
                        SqlCommand cmd3 = new SqlCommand("INSERT INTO ", conNorthwind);
                        SqlCommand cmd4 = new SqlCommand("UPDTATE ", conNorthwind);
                        conNorthwind.Open();
                        cmd3.ExecuteNonQuery();
                        cmd4.ExecuteNonQuery();
                    }
                }
                tsScope.Complete();
            }
        }

    }
}

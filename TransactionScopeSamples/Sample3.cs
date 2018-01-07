using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace TransactionScopeSamples
{
    /// <summary>
    /// Async Sample
    /// </summary>
    public class Sample3
    {
        public static async Task AsyncSampleAsync()
        {
            //Important : TransactionScopeAsyncFlowOption.Enabled
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var conn = new SqlConnection("Northwind Connection String"))
                {
                    await conn.OpenAsync();

                    SqlCommand cmd1 = new SqlCommand("INSERT INTO ", conn);
                    await cmd1.ExecuteNonQueryAsync();

                    //In Addition, We can add entityframework commands or others here 
                    //using (var context = new NorthwindContext(conn))
                    //{
                    //    var query = context.Orders.Where(x => x.OrderId == 1000).FirstOrDefault();
                    //    query.Address = "Street, Avenue, No:15 etc.";
                    //    await context.SaveChangesAsync();
                    //}                    
                }
                scope.Complete();
            }
        }
    }
}

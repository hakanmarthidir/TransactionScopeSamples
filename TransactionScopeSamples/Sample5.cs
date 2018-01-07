using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TransactionScopeSamples
{
    /// <summary>
    /// Implicit Transactions
    /// </summary>
    public class Sample5
    {
        public void ImplicitTransaction()
        {
            using (TransactionScope scope1 = new TransactionScope())              
            {               
                using (TransactionScope scope2 = new TransactionScope(TransactionScopeOption.Required))
                {
                    //Default is Required 
                    scope2.Complete();
                }
                using (TransactionScope scope3 = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    scope3.Complete();
                }
                using (TransactionScope scope4 = new TransactionScope(TransactionScopeOption.Suppress))
                {
                    //No transactional code
                    //we can use this section logging or audit operations.
                }
                scope1.Complete();
            }
        }
        //
        //Scope Options         Ambient Trans  The scope takes part in     
        //Required(Default)          No        New Transaction(will be the root)
        //Requires                   New       No New Transaction(will be the root)
        //Suppress                   No        No Transaction
        //Required                   Yes       Ambient Transaction
        //Requires                   New       Yes New Transaction(will be the root)
        //Suppress                   Yes       No Transaction
    }
}

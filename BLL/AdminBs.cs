using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace BLL
{
    public class AdminBs :BaseBs
    {
        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    foreach (var item in Ids)
                    {
                        var myUrl = urlBs.GetByID(item);
                        myUrl.IsApproved = Status;
                        urlBs.Update(myUrl);
                    }

                    Trans.Complete();
                }
                catch (Exception E1)
                {
                    throw new Exception(E1.Message);
                }


            }
        }
    }
}

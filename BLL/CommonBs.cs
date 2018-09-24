using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.Web;
using System.Transactions;
namespace BLL
{
    public class CommonBs : BaseBs
    {

        public void InsertQuickUrl(QuickSubmitURLModel myQuickUrl)
        {
            using (TransactionScope Trans = new TransactionScope())
            {
                try
                {
                    tbl_User user = myQuickUrl.User;
                    user.Password = user.ConfirmPassword = "123456";
                    user.Role = "U";
                    userBs.Insert(user);

                    tbl_Url myUrl = myQuickUrl.MyUrl;
                    myUrl.UserId = user.UserId;
                    myUrl.UrlDesc = myUrl.UrlTitle;
                    myUrl.IsApproved = "P";
                    urlBs.Insert(myUrl);

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

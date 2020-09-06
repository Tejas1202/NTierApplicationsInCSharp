using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PluralSightBookWebsite.Code
{
    public class UserParameter : Parameter
    {
        protected override object Evaluate(HttpContext context, Control control)
        {
            var currentUser = Membership.GetUser();
            this.DbType = System.Data.DbType.Guid;

            return currentUser.ProviderUserKey;
        }
    }
}
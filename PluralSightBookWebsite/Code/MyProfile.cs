using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace PluralSightBookWebsite.Code
{
    public class MyProfile : ProfileBase
    {
        public static MyProfile CurrentUser
        {
            get
            {
                return (MyProfile)(ProfileBase
                    .Create(Membership.GetUser().UserName));
            }
        }
            
        public string Name
        {
                get { return ((string)(base["Name"])); }
                set { base["Name"] = value; Save(); }
        }

        public string FavoritePluralsightAuthor
        {
            get { return ((string)(base["FavoritePluralsightAuthor"])); }
            set { base["FavoritePluralsightAuthor"] = value; Save(); }
        }
    }
}
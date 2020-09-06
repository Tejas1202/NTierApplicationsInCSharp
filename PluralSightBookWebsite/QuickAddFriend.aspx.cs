using Pluralsight.BLL;
using PluralSightBookWebsite.Code;
using System;
using System.Web.Security;

namespace PluralSightBookWebsite
{
    public partial class QuickAddFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;
            string currentUserName = MyProfile.CurrentUser.Name;
            string currentUserEmail = Membership.GetUser().Email;
            string friendEmail = Request.QueryString["email"];
            var friendsService = new FriendsService();
            friendsService.AddFriend(currentUserId, currentUserEmail, currentUserName, friendEmail);

            SuccessLabel.Text = "Added friend: " + Request.QueryString["email"];
        }
    }
}
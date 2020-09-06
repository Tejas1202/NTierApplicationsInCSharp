//using Pluralsight.BLL;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using PluralSightBook.Infrastructure.Data;
using PluralSightBook.Infrastructure.Services;
using PluralSightBookWebsite.Code;
using System;
using System.Web.Security;

namespace PluralSightBookWebsite
{
    public partial class AddFriend : BasePage
    {
        public IFriendsService FriendsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;
            string currentUserName = MyProfile.CurrentUser.Name;
            string currentUserEmail = Membership.GetUser().Email;
            string friendEmail = EmailTextBox.Text;
            //var friendsService = new FriendsService(
            //    new NotificationService(
            //        new EfQueryUserByEmail(), new DebugEmailSender()), 
            //    new EfFriendRepository());
            //friendsService.AddFriend(currentUserId, currentUserEmail, currentUserName, friendEmail);

            FriendsService.AddFriend(currentUserId, currentUserEmail, currentUserName, friendEmail);

            Response.Redirect("Friends.aspx", true);
        }
    }
}
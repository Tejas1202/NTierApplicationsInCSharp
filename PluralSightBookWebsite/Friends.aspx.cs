using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using PluralSightBook.Infrastructure.Data;
using PluralSightBook.Infrastructure.Services;
using PluralSightBookWebsite.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PluralSightBookWebsite
{
    public partial class Friends : BasePage
    {
        public IFriendsService FriendsService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;

            //var friendsService = new FriendsService(
            //    new NotificationService(
            //        new EfQueryUserByEmail(), new DebugEmailSender()),
            //    new EfFriendRepository());

            //GridView1.DataSource = friendsService.ListFriendsOf(currentUserId).ToList();

            GridView1.DataSource = FriendsService.ListFriendsOf(currentUserId).ToList();
            GridView1.DataBind();
        }

        protected void Delete_LinkButton_Click(object sender, EventArgs e)
        {
            int friendId = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            //var friendsService = new FriendsService(
            //    new NotificationService(
            //        new EfQueryUserByEmail(), new DebugEmailSender()),
            //    new EfFriendRepository());

            //friendsService.DeleteFriend(friendId);

            FriendsService.DeleteFriend(friendId);
            BindGridView();
        }
    }
}
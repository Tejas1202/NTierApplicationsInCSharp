using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PluralSightBookWebsite.Code;

namespace PluralSightBookWebsite.Account
{
    public partial class EditProfile : System.Web.UI.Page
    {
        public MyProfile CurrentUser
        {
            get
            {
                return MyProfile.CurrentUser;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NameTextBox.Text = CurrentUser.Name;
                FavoriteAuthorTextBox.Text = CurrentUser.FavoritePluralsightAuthor;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            CurrentUser.Name = NameTextBox.Text;
            CurrentUser.FavoritePluralsightAuthor = FavoriteAuthorTextBox.Text;
            Response.Redirect("/Profile.aspx", true);
        }
    }
}
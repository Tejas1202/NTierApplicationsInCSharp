using StructureMap;

namespace PluralSightBookWebsite.Code
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            ObjectFactory.BuildUp(this);
        }
    }
}
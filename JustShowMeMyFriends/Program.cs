using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustShowMeMyFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            StructureMapBootStrap.Configure();

            string userEmail = ConfigurationManager.AppSettings["userEmailAddress"];

            var friendsReport = ObjectFactory.GetInstance<FriendsReport>();

            Console.WriteLine(friendsReport.ShowFriendsReport(userEmail));
            Console.ReadKey();
        }
    }
}

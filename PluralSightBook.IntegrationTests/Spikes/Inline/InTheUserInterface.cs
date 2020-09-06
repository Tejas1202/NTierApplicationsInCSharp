using PluralSightBook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.Inline
{
    // Hence if we choose to persist in the UI itself, we'll violate DRY principle as we've to repeat same logic of persistence everywhere else
    // Also it violates Seperation of Concerns which is like the foundation of DDD architechture or any layered application
    public class InTheUserInterface
    {
        public void Button_Click()
        {
            // read some values from UI elements
            Guid currentUserId = Guid.NewGuid(); // (Guid)Membership.GetUser().ProviderUserKey;
            string friendEmail = ""; // EmailTextBox.Text;

            // maybe do some validation

            // save stuff to the database
            using (var context = new aspnetdbEntities())
            {
                var friend = context.Friends.Create();
                friend.EmailAddress = friendEmail;
                friend.UserId = currentUserId;
                context.Friends.Add(friend);
                context.SaveChanges();
            }

            // maybe update a label or redirect
        }
    }
}

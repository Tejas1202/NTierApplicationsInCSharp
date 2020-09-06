using PluralSightBook.Data;
using PluralSightBook.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.IntegrationTests.Spikes.CodeFirst
{
    public class TestDbInitializer : DropCreateDatabaseAlways<PluralSightBookContext>
    {
        public const string TEST_EMAIL = "test@domain.com";
        public const string TEST_USERNAME = "testuser";
        public void Reseed(PluralSightBookContext context)
        {
            Seed(context);
        }

        protected override void Seed(PluralSightBookContext context)
        {
            try
            {
                //var tables = new List<string>() 
                //{
                //    "aspnet_Application",
                //    "aspnet_Membership",
                //    "aspnet_User",
                //    "Friend"
                //};
                //foreach (var tableName in tables)
                //{
                //    context.Database.ExecuteSqlCommand(string.Format("DELETE {0}", tableName));
                //    context.SaveChanges();
                //}
                aspnet_Applications app = context.aspnet_Applications.FirstOrDefault(a => a.ApplicationName == "Test");
                if (app == null)
                {
                    app = new aspnet_Applications()
                    {
                        ApplicationId = Guid.NewGuid(),
                        ApplicationName = "Test",
                        Description = "Test App",
                        LoweredApplicationName = "test"
                    };
                    context.aspnet_Applications.Add(app);
                }
                aspnet_Users user = context.aspnet_Users.FirstOrDefault(u => u.UserName == TEST_USERNAME);
                if (user == null)
                {
                    user = new aspnet_Users()
                    {
                        ApplicationId = app.ApplicationId,
                        UserId = Guid.NewGuid(),
                        UserName = TEST_USERNAME,
                        LastActivityDate = DateTime.Now,
                        LoweredUserName = TEST_USERNAME
                    };
                    context.aspnet_Users.Add(user);
                }
                aspnet_Membership member = context.aspnet_Membership.FirstOrDefault(m => m.UserId == user.UserId);
                if (member == null)
                {
                    member = new aspnet_Membership()
                    {
                        ApplicationId = app.ApplicationId,
                        CreateDate = DateTime.Now,
                        Email = TEST_EMAIL,
                        LoweredEmail = TEST_EMAIL,
                        Password = String.Empty,
                        PasswordSalt = String.Empty,
                        UserId = user.UserId,
                        LastPasswordChangedDate = DateTime.Now,
                        LastLockoutDate = DateTime.Now,
                        LastLoginDate = DateTime.Now,
                        Comment = String.Empty,
                        FailedPasswordAnswerAttemptCount = 0,
                        FailedPasswordAnswerAttemptWindowStart = DateTime.Now,
                        FailedPasswordAttemptCount = 0,
                        FailedPasswordAttemptWindowStart = DateTime.Now
                    };
                    context.aspnet_Membership.Add(member);
                }
                context.SaveChanges();
                // remove test user's friends
                foreach (var friend in context.Friends.Where(f => f.UserId == user.UserId))
                {
                    context.Friends.Remove(friend);
                }
                context.SaveChanges();
            }
            //catch (DbEntityValidationException ex)
            //{
            //    Console.Error.WriteLine(ex.ToString());
            //    foreach (var errors in ex.EntityValidationErrors)
            //    {
            //        foreach (var error in errors.ValidationErrors)
            //        {
            //            Console.Error.WriteLine("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage);
            //        }
            //    }
            //}
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
            base.Seed(context);
        }
    }
}

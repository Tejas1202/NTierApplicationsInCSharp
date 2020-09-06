namespace PluralSightBook.Core.Interfaces
{
    public interface INotificationService
    {
        void SendNotification(string currentUserEmail, string currentUserName, string friendEmail);
    }
}

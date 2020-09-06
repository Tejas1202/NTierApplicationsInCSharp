using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.Data.Models
{
    public class aspnet_Applications
    {
        public aspnet_Applications()
        {
            this.aspnet_Membership = new List<aspnet_Membership>();
            this.aspnet_Users = new List<aspnet_Users>();
        }

        public string ApplicationName { get; set; }
        public string LoweredApplicationName { get; set; }
        public System.Guid ApplicationId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }
    }
}

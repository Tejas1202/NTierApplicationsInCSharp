using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSightBook.Data.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public System.Guid UserId { get; set; }
        public virtual aspnet_Membership aspnet_Membership { get; set; }
    }
}

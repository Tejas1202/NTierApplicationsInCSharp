//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PluralSight.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Friends
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public System.Guid UserId { get; set; }
    
        public virtual aspnet_Membership aspnet_Membership { get; set; }
    }
}

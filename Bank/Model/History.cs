//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bank.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int OperationID { get; set; }
        public string NameOperation { get; set; }
        public System.DateTime DateTime { get; set; }
        public double Amount { get; set; }
        public string Account { get; set; }
    
        public virtual BankAccounts BankAccounts { get; set; }
    }
}

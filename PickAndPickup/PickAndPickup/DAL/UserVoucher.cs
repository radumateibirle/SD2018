//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserVoucher
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> VoucherID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual User User { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
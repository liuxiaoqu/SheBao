//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Langben.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierBill
    {
        public string Id { get; set; }
        public Nullable<int> SupplierId { get; set; }
        public string PayName { get; set; }
        public string BillName { get; set; }
        public string TaxRegistryNumber { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public string Status { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
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
    
    public partial class CRM_CompanyContract_Audit
    {
        public int ID { get; set; }
        public Nullable<int> CRM_CompanyContract_ID { get; set; }
        public Nullable<int> CRM_Company_ID { get; set; }
        public Nullable<int> CRM_Company_Audit_ID { get; set; }
        public Nullable<int> BillDay { get; set; }
        public Nullable<int> ReceivedDay { get; set; }
        public string FeesCycle { get; set; }
        public Nullable<int> ChangeDay { get; set; }
        public Nullable<int> DatumDay { get; set; }
        public Nullable<System.DateTime> ServceEndDay { get; set; }
        public Nullable<int> SendBillDay { get; set; }
        public Nullable<System.DateTime> ServiceBeginDay { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public int BranchID { get; set; }
        public int OperateStatus { get; set; }
        public int OperateNode { get; set; }
    }
}

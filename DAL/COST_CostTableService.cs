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
    
    public partial class COST_CostTableService
    {
        public int ID { get; set; }
        public int COST_CostTable_ID { get; set; }
        public int PaymentStyle { get; set; }
        public decimal ChargeCost { get; set; }
        public Nullable<decimal> ServiceCoset { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public string EmployName { get; set; }
        public string CertificateType { get; set; }
        public string CertificateNumber { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int CRM_Company_ID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
        public int BranchID { get; set; }
    }
}

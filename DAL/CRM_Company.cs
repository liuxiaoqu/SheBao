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
    
    public partial class CRM_Company
    {
        public int ID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Dict_HY_Code { get; set; }
        public string OrganizationCode { get; set; }
        public string RegisterAddress { get; set; }
        public string OfficeAddress { get; set; }
        public int Source { get; set; }
        public Nullable<int> OperateStatus { get; set; }
        public Nullable<int> ParentID { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    }
}

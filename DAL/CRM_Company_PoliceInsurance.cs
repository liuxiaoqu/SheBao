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
    
    public partial class CRM_Company_PoliceInsurance
    {
        public int ID { get; set; }
        public Nullable<int> CRM_Company_ID { get; set; }
        public Nullable<int> InsuranceKind { get; set; }
        public Nullable<int> PoliceInsurance { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdatePerson { get; set; }
    }
}

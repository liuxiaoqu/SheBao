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
    
    public partial class InsuranceKind
    {
        public InsuranceKind()
        {
            this.Attachment = new HashSet<Attachment>();
            this.ORG_UserInsuranceKind = new HashSet<ORG_UserInsuranceKind>();
            this.PoliceCascadeRelationship = new HashSet<PoliceCascadeRelationship>();
            this.PoliceInsurance = new HashSet<PoliceInsurance>();
            this.PoliceMasterRelationship = new HashSet<PoliceMasterRelationship>();
            this.PoliceOperation = new HashSet<PoliceOperation>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Remark { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string UpdatePerson { get; set; }
        public Nullable<int> InsuranceKindId { get; set; }
    
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual City City1 { get; set; }
        public virtual ICollection<ORG_UserInsuranceKind> ORG_UserInsuranceKind { get; set; }
        public virtual ICollection<PoliceCascadeRelationship> PoliceCascadeRelationship { get; set; }
        public virtual ICollection<PoliceInsurance> PoliceInsurance { get; set; }
        public virtual ICollection<PoliceMasterRelationship> PoliceMasterRelationship { get; set; }
        public virtual ICollection<PoliceOperation> PoliceOperation { get; set; }
    }
}

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
    
    public partial class LadderPrice
    {
        public string Id { get; set; }
        public Nullable<decimal> SinglePrice { get; set; }
        public Nullable<int> EndLadder { get; set; }
        public Nullable<int> BeginLadder { get; set; }
        public string LadderLowestPriceId { get; set; }
        public string Status { get; set; }
        public Nullable<int> BranchID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateUserID { get; set; }
        public string CreateUserName { get; set; }
    
        public virtual LadderLowestPrice LadderLowestPrice { get; set; }
    }
}

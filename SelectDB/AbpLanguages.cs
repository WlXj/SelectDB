//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SelectDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AbpLanguages
    {
        public int Id { get; set; }
        public Nullable<int> TenantId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> DeleterUserId { get; set; }
        public Nullable<System.DateTime> DeletionTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
    }
}

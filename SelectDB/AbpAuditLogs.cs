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
    
    public partial class AbpAuditLogs
    {
        public long Id { get; set; }
        public Nullable<int> TenantId { get; set; }
        public Nullable<long> UserId { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Parameters { get; set; }
        public System.DateTime ExecutionTime { get; set; }
        public int ExecutionDuration { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public string BrowserInfo { get; set; }
        public string Exception { get; set; }
        public Nullable<long> ImpersonatorUserId { get; set; }
        public Nullable<int> ImpersonatorTenantId { get; set; }
        public string CustomData { get; set; }
    }
}

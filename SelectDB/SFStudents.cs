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
    
    public partial class SFStudents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SFStudents()
        {
            this.SFClasses = new HashSet<SFClasses>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string PenSerial { get; set; }
        public string PenNo { get; set; }
        public Nullable<int> PenUID { get; set; }
        public Nullable<int> PenNum { get; set; }
        public Nullable<int> VoteNum { get; set; }
        public string PageId { get; set; }
        public Nullable<int> xMin { get; set; }
        public Nullable<int> xMax { get; set; }
        public Nullable<int> yMin { get; set; }
        public Nullable<int> yMax { get; set; }
        public int SchoolId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SFClasses> SFClasses { get; set; }
    }
}

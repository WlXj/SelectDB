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
    
    public partial class SFClasses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SFClasses()
        {
            this.SFStudents = new HashSet<SFStudents>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassGUID { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public string TeacherName { get; set; }
        public bool IsShared { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SFStudents> SFStudents { get; set; }
    }
}
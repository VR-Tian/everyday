//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryProery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoryProery()
        {
            this.CategoryProeryValue = new HashSet<CategoryProeryValue>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsRequire { get; set; }
        public bool IsMult { get; set; }
        public int SortOrder { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryProeryValue> CategoryProeryValue { get; set; }
    }
}
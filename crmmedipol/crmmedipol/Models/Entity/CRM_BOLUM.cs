//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crmmedipol.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRM_BOLUM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRM_BOLUM()
        {
            this.CRM_OKUL = new HashSet<CRM_OKUL>();
        }
    
        public byte ID { get; set; }
        public string BOLUMADI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_OKUL> CRM_OKUL { get; set; }
    }
}
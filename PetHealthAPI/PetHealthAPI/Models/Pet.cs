//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetHealthAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pet()
        {
            this.ClinicalHistory = new HashSet<ClinicalHistory>();
        }
    
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string Key { get; set; }
        public string Status { get; set; }
        public string Race { get; set; }
        public System.DateTime BirthDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClinicalHistory> ClinicalHistory { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblMusteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMusteri()
        {
            this.tblSatislar = new HashSet<tblSatislar>();
        }
    
        public int MUSTERIID { get; set; }

        [Required(ErrorMessage ="Bu Alan� Bo� B�rakamazs�n�z!")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter!!!")]
        public string MUSTERIAD { get; set; }
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSatislar> tblSatislar { get; set; }
    }
}

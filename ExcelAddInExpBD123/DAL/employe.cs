//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelAddInExpBD123.DAL {
    using System;
    using System.Collections.Generic;

    public partial class employe {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employe() {
            this.employe1 = new HashSet<employe>();
        }

        public int id { get; set; }
        public Nullable<int> id_departement { get; set; }
        public Nullable<int> id_patron { get; set; }
        public string nom { get; set; }
        public string poste { get; set; }
        public Nullable<System.DateTime> date_embauche { get; set; }
        public Nullable<decimal> salaire { get; set; }
        public Nullable<decimal> commission { get; set; }

        public virtual departement departement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employe> employe1 { get; set; }
        public virtual employe employe2 { get; set; }
    }
}
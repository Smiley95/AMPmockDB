//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMPmockDB.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Investor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Investor()
        {
            this.Portfolio = new HashSet<Portfolio>();
            Investor_ID = Guid.NewGuid();
        }
    
        public System.Guid Investor_ID { get; set; }
        public string Investor_FullName { get; set; }
        public System.DateTime Investor_birth { get; set; }
        public System.DateTime Investor_timeHorizon { get; set; }
        public string Investor_email { get; set; }
        public string Expert_ID { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio> Portfolio { get; set; }
    }
}

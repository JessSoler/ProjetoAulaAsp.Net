//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoTesteAula.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venda()
        {
            this.VendaItens = new HashSet<VendaIten>();
        }
    
        public int ID { get; set; }
        public int IDCliente { get; set; }
        public System.DateTime Data { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendaIten> VendaItens { get; set; }
    }
}

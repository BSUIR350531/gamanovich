//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChooseYourBike.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brakes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brakes()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int ID { get; set; }
        public string FrBrakeName { get; set; }
        public string FrBrakeType { get; set; }
        public string RrBrakeName { get; set; }
        public string RrBrakeType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
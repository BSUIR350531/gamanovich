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
    
    public partial class Comments
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Nullable<int> Comments_ID { get; set; }
    
        public virtual Product Product1 { get; set; }
    }
}

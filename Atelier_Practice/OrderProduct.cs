//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atelier_Practice
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderProduct
    {
        public int ID_Order { get; set; }
        public int ID_Product { get; set; }
        public int ID_Pattern { get; set; }
        public int CountProduct { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Pattern Pattern { get; set; }
        public virtual Product Product { get; set; }

        public string NameProduct 
        {
            get 
            {
                return this.Product.NameProduct.ToString();   
            }
        }
    }
}

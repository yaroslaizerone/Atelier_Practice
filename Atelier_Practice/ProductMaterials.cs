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
    
    public partial class ProductMaterials
    {
        public int ID_Product { get; set; }
        public int ID_Materials { get; set; }
        public int CountMaterialInProduct { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Product Product { get; set; }
    }
}

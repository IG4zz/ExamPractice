//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductStore.DBEntities
{
    using System;
    using System.Collections.Generic;

    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            this.Sellings = new HashSet<Selling>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double ActualPrice
        {
            get
            {
                return (Price - (Price * Discount));
            }
            set
            {

            }
        }
        public Nullable<double> TempPrice
        {
            get
            {
                if (Discount == 0) return null;
                else return (double)Price;
            }
            set
            {

            }
        }
       
        public string Image { get; set; }
        public int IdType { get; set; }
    
        public virtual Type Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}

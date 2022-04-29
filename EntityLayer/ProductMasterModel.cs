using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class ProductMasterModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public string Image { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public int CategoryID { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string SCreatedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsModified { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<int> ProductQty { get; set; }

       
        public virtual ICollection<CustomerOrderMasterModel> CustomerOrderMasters { get; set; }
        public virtual ProductCategoryModel ProductCategory { get; set; }
    }
}

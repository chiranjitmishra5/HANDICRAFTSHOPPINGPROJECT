using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UrlMasterModel
    {
        public int UrlID { get; set; }
        public string AcctionName { get; set; }
        public string ControllerName { get; set; }
       
        public virtual ICollection<ProductCategoryModel> ProductCategories { get; set; }
    }
}

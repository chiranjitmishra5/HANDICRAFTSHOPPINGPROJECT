using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class DetailsViewModel
    {
        public List<ProductMasterModel> productDetails { get; set; }
        public List<CustomerRegisterMasterModel> CustomerDetails { get; set; }
    }
}

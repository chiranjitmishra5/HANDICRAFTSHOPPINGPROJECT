using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerOrderMasterModel
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<double> ProductQty { get; set; }

        public virtual CustomerRegisterMasterModel CustomerRegisterMaster { get; set; }
        public virtual ProductMasterModel ProductMaster { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserLoginMasterModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Age { get; set; }
        public Nullable<int> DEgID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Pass { get; set; }
        public string PassKey { get; set; }
    }
}

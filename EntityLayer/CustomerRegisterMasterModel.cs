using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerRegisterMasterModel
    {
        public int CustomerID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string PinCode { get; set; }
        public string ProfilePic { get; set; }
        public string Pass { get; set; }
        public string PassKey { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ProductNumberInCard { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public bool IsModifide { get; set; }
        public Nullable<int> AccountID { get; set; }

       
        public virtual ICollection<CustomerOrderMasterModel> CustomerOrderMasters { get; set; }
        public virtual ProductMasterModel ProductMaster { get; set; }
    }
}

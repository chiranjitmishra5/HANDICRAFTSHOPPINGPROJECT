using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class DesignationMasterModel
    {
        public int DEgID { get; set; }
        public string Designation { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public bool IsModified { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}

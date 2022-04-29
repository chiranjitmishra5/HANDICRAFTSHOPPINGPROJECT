using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLayer
{
   public class ProductProcess:BaseProcess
    {
        ShopingDBEntities _db = new ShopingDBEntities();

        public CategoryListViewModel GetCategory()
        {
            CategoryListViewModel model = new CategoryListViewModel();
            model.CategoryList = _db.ProductCategories.ToList().Where(a => a.IsActive == true).Select(a => Convert<ProductCategory, ProductCategoryModel>(a)).ToList();
            return model;
        }

        public CustomerRegisterMasterModel LogIn(string UserId, string Pass)
        {

            var data = _db.CustomerRegisterMasters.ToList().Where(a => a.EmailAddress == UserId || a.PhoneNo == UserId && a.Pass == Pass).Select(a => Convert<CustomerRegisterMaster, CustomerRegisterMasterModel>(a)).FirstOrDefault();
            return data;
        }

        public ProductMasterModel SetProduct(ProductMasterModel model)
        {
            try
            {

                var dbModel = new ProductMaster();
                if (model.ProductID == 0)
                {
                    model.CreatedOn = DateTime.Now;
                    model.CreateBy = 2;
                    model.IsActive = true;
                    var x = Convert<ProductMasterModel, ProductMaster>(model);
                    _db.ProductMasters.Add(x);
                    _db.SaveChanges();
                    return Convert<ProductMaster, ProductMasterModel>(x);
                }
                else
                {
                    var x1 = Convert<ProductMasterModel, ProductMaster>(model);
                    _db.Entry(x1).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Convert<ProductMaster, ProductMasterModel>(dbModel);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ProductMasterModel ProductGETByProductID(int ProductID)
        {
            var data = _db.ProductMasters.Where(a => a.ProductID == ProductID).Select(a => Convert<ProductMaster, ProductMasterModel>(a)).FirstOrDefault();
            return data;
        }

        public List<ProductMasterModel> GetProductList()
        {
            var data = _db.ProductMasters.ToList().Where(a => a.IsActive == true).ToList();
            return data.Select(a => ProductConvert(a)).ToList();

        }

        public bool DeleteProduct(int ID)
        {
            try
            {
                var data = _db.ProductMasters.Where(a => a.ProductID == ID).FirstOrDefault();
                data.IsActive = false;
                _db.Entry(data).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public ProductMasterModel GetProductByID(int ID)
        {
            var data = _db.ProductMasters.ToList().Where(a => a.ProductID == ID).Select(a => Convert<ProductMaster, ProductMasterModel>(a)).FirstOrDefault();
            return data;
        }


        public List<ProductMasterModel> GetProductListByID(int CategoryID)
        {
            var data = _db.ProductMasters.ToList().Where(a => a.IsActive == true && a.CategoryID == CategoryID).Select(a => Convert<ProductMaster, ProductMasterModel>(a)).ToList();
            return data;

        }


        public ProductMasterModel GetProductDetailsByProductID(int ProductID)
        {
            var data = _db.ProductMasters.ToList().Where(a => a.IsActive == true && a.ProductID == ProductID).Select(a => Convert<ProductMaster, ProductMasterModel>(a)).FirstOrDefault();
            return data;

        }

        public DetailsViewModel GetProductDetailsByProductID1(int ProductID, int custID)
        {
            DetailsViewModel model = new DetailsViewModel();
            var data = _db.ProductMasters.ToList().Where(a => a.IsActive == true && a.ProductID == ProductID).Select(a => Convert<ProductMaster, ProductMasterModel>(a)).ToList();
            var Cdata = _db.CustomerRegisterMasters.ToList().Where(a => a.IsActive == true && a.CustomerID == custID).Select(a => Convert<CustomerRegisterMaster, CustomerRegisterMasterModel>(a)).ToList();
            model.productDetails = data;
            model.CustomerDetails = Cdata;
            return model;

        }


    }
}

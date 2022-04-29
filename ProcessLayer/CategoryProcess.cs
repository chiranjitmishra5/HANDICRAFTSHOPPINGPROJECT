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
    public class CategoryProcess:BaseProcess
    {
        ShopingDBEntities _db = new ShopingDBEntities();
        public CategoryListViewModel GetCategory()
        {
            CategoryListViewModel model = new CategoryListViewModel();
            var data = _db.ProductCategories.ToList();
            model.CategoryList = data.Select(a => Convert(a)).ToList();
            return model;
        }

        public ProductCategoryModel GetCategoryByID(int ID)
        {
            var data = _db.ProductCategories.ToList().Where(a => a.CategoryID == ID).Select(a => Convert<ProductCategory, ProductCategoryModel>(a)).FirstOrDefault();
            return data;
        }

        public bool UpdateCategory(int ID, string CategoryName)
        {
            try
            {
                var data = _db.ProductCategories.Where(a => a.CategoryID == ID).FirstOrDefault();
                data.ModifiedOn = DateTime.Now;
                data.IsActive = true;
                data.CategoryName = CategoryName;
                data.IsModified = true;
                _db.Entry(data).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteCategory(int ID)
        {
            try
            {
                var data = _db.ProductCategories.Where(a => a.CategoryID == ID).FirstOrDefault();
                data.IsDeleted = true;
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

        public ProductCategoryModel SetCategory(ProductCategoryModel model)
        {
            try
            {

                var dbModel = new ProductCategory();
                if (model.CategoryID == 0)
                {
                    model.CreatedOn = DateTime.Now;
                    model.IsDeleted = false;
                    model.IsActive = true;
                    model.ModifiedOn = DateTime.Now;
                    var x = Convert<ProductCategoryModel, ProductCategory>(model);
                    _db.ProductCategories.Add(x);
                    _db.SaveChanges();
                    return Convert<ProductCategory, ProductCategoryModel>(x);
                }
                else
                {
                    var x1 = Convert<ProductCategoryModel, ProductCategory>(model);
                    model.ModifiedOn = DateTime.Now;
                    _db.Entry(x1).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Convert<ProductCategory, ProductCategoryModel>(dbModel);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public CustomerRegisterMasterModel SetCustomer(CustomerRegisterMasterModel model)
        {
            try
            {

                var dbModel = new CustomerRegisterMaster();
                if (model.CustomerID == 0)
                {
                    model.CreatedOn = DateTime.Now;
                    model.AccountID = 2;
                    model.IsDeleted = false;
                    model.IsActive = true;
                    model.ModifiedOn = DateTime.Now;
                    var x = Convert<CustomerRegisterMasterModel, CustomerRegisterMaster>(model);
                    _db.CustomerRegisterMasters.Add(x);
                    _db.SaveChanges();
                    return Convert<CustomerRegisterMaster, CustomerRegisterMasterModel>(x);
                }
                else
                {
                    var x1 = Convert<CustomerRegisterMasterModel, CustomerRegisterMaster>(model);
                    model.ModifiedOn = DateTime.Now;
                    _db.Entry(x1).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Convert<CustomerRegisterMaster, CustomerRegisterMasterModel>(dbModel);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

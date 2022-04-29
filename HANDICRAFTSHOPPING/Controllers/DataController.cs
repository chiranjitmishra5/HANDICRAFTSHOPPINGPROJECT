using EntityLayer;
using ProcessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HANDICRAFTSHOPPING.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCategoryList()
        {
            var data = new ProductProcess().GetCategory();
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult AddNewProduct(ProductMasterModel Model)
        {
            if (Request.Files != null)
            {
                try
                {
                    Model.CreatedOn = DateTime.Now;
                    Model.ProductName.ToUpper();
                    Model.IsActive = true;
                    Model.IsModified = false;
                    Model.IsActive = true;
                    var Image = Request.Files[0];
                    var Image1 = Request.Files[1];
                    var Image2 = Request.Files[2];
                    string image = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    string image1 = Guid.NewGuid() + Path.GetExtension(Image1.FileName);
                    string image2 = Guid.NewGuid() + Path.GetExtension(Image2.FileName);
                    Model.Image = "/Images/ProductPicture/" + image;
                    Model.Image1 = "/Images/ProductPicture/" + image1;
                    Model.Image2 = "/Images/ProductPicture/" + image2;
                    string profile = System.IO.Path.Combine(Server.MapPath("~/Images/ProductPicture"), image);
                    string profile1 = System.IO.Path.Combine(Server.MapPath("~/Images/ProductPicture"), image1);
                    string profile2 = System.IO.Path.Combine(Server.MapPath("~/Images/ProductPicture"), image2);
                    Image.SaveAs(profile);
                    Image1.SaveAs(profile1);
                    Image2.SaveAs(profile2);
                    var data = new ProductProcess().SetProduct(Model);
                    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                catch (Exception ex)
                {
                    return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        public JsonResult GetAllCategory()
        {
            var data = new CategoryProcess().GetCategory();
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetCategoryByID(int ID)
        {
            var data = new CategoryProcess().GetCategoryByID(ID);
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult UpdateCategory(string CategoryName, int ID)
        {
            var data = new CategoryProcess().UpdateCategory(ID, CategoryName);
            if (data == true)
            {
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        public JsonResult DeleteCategory(int ID)
        {
            var data = new CategoryProcess().DeleteCategory(ID);
            if (data == true)
            {
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult AddCategory(ProductCategoryModel Model)
        {
            if (Request.Files != null)
            {
                try
                {

                    Model.CreatedOn = DateTime.Now;
                    Model.ModifiedOn = DateTime.Now;
                    Model.IsDeleted = false;
                    Model.IsModified = false;
                    Model.DeletedOn = null;
                    ProductCategoryModel m = new ProductCategoryModel();
                    var data = new CategoryProcess().SetCategory(Model);
                    if (data.CategoryID > 0)
                    {

                        return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                    }


                }
                catch (Exception ex)
                {
                    return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }
        public JsonResult ProductDetails()
        {
            var data = new ProductProcess().GetProductList();
            if (data == null)
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }



       
        public JsonResult DeleteProduct(int ID)
        {
            var data = new ProductProcess().DeleteProduct(ID);
            if (data == true)
            {
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

        public JsonResult GetProductID(int ID)
        {
            var data = new ProductProcess().GetProductByID(ID);
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ProductDetailsByID(int CategoryID)
        {
            var data = new ProductProcess().GetProductListByID(CategoryID);
            if (data == null)
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult ProductDetailsByProductID(int ProductID)
        {
            var data = new ProductProcess().GetProductDetailsByProductID(ProductID);
            if (data == null)
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        public JsonResult ProductDetailsByProductID1(int ProductID, int CustID)
        {
            var data = new ProductProcess().GetProductDetailsByProductID1(ProductID, CustID);
            if (data == null)
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public JsonResult LoginUser(string UserId, string Password)
        {
            var data = new ProductProcess().LogIn(UserId, Password);
            if (data != null)
            {
               Session["ID"] = data.CustomerID;
                Session["Name"] = data.FName+" "+data.LName;
                return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else {
                Session["ID"] =null;
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }          
        }

        public JsonResult AddCustomer(CustomerRegisterMasterModel Model)
        {
            if (Request.Files != null)
            {
                try
                {

                    Model.CreatedOn = DateTime.Now;
                    Model.ModifiedOn = DateTime.Now;
                    Model.IsDeleted = false;
                    Model.IsModifide = false;
                    Model.IsActive = true;

                    CustomerRegisterMasterModel m = new CustomerRegisterMasterModel();
                    var data = new CategoryProcess().SetCustomer(Model);
                    if (data.CustomerID > 0)
                    {

                        return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    }
                    else
                    {
                        return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                    }


                }
                catch (Exception ex)
                {
                    return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }


    }
}
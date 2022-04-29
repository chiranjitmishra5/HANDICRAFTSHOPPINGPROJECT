using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLayer
{
    public class BaseProcess
    {

        public ProductCategoryModel Convert(ProductCategory Model)
        {
            return new ProductCategoryModel { IsActive = Model.IsActive, IsDeleted = Model.IsDeleted, CategoryID = Model.CategoryID, CategoryName = Model.CategoryName, SCreatedOn = System.Convert.ToDateTime(Model.CreatedOn).ToString("dd/MM/yyyy") };
        }

        public ProductMasterModel ProductConvert(ProductMaster Model)
        {
            return new ProductMasterModel { IsActive = Model.IsActive, IsModified = Model.IsModified, CategoryID = Model.CategoryID, ProductName = Model.ProductName, SCreatedOn = System.Convert.ToDateTime(Model.CreatedOn).ToString("dd/MM/yyyy"), ProductPrice = Model.ProductPrice, ProductID = Model.ProductID, ProductQty = Model.ProductQty, Description = Model.Description, Image = Model.Image, Image1 = Model.Image1, Image2 = Model.Image2 };
        }

        public T2 Convert<T1, T2>(T1 data) where T2 : new()
        {
            T2 obj = new T2();
            PropertyDescriptorCollection objPropertyDescriptorCollectionT1 = TypeDescriptor.GetProperties(typeof(T1));
            PropertyDescriptorCollection objPropertyDescriptorCollectionT2 = TypeDescriptor.GetProperties(typeof(T2));
            foreach (PropertyDescriptor PropertyDescriptor in objPropertyDescriptorCollectionT1)
            {
                PropertyInfo pi = PropertyDescriptor.ComponentType.GetProperty(PropertyDescriptor.Name);
                var value = pi.GetValue(data, null);
                var prop = typeof(T2).GetProperties().FirstOrDefault(n => n.CanRead && n.CanWrite && n.Name == PropertyDescriptor.Name && n.PropertyType == PropertyDescriptor.PropertyType);
                if (prop != null)
                {
                    prop.SetValue(obj, value, null);
                }
            }
            return obj;
        }
        //ASE Encryption
        public string Encrypt(string clearText, string EncryptionKey)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = System.Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        //CreatPasssword
        public string GeneratePassword(int Length, int NonAlphaNumericChars)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            string allowedNonAlphaNum = "!@#$%^&*()_-+=[{]};:<>|./?";
            Random rd = new Random();

            if (NonAlphaNumericChars > Length || Length <= 0 || NonAlphaNumericChars < 0)
                throw new ArgumentOutOfRangeException();

            char[] pass = new char[Length];
            int[] pos = new int[Length];
            int i = 0, j = 0, temp = 0;
            bool flag = false;

            //Random the position values of the pos array for the string Pass
            while (i < Length - 1)
            {
                j = 0;
                flag = false;
                temp = rd.Next(0, Length);
                for (j = 0; j < Length; j++)
                    if (temp == pos[j])
                    {
                        flag = true;
                        j = Length;
                    }

                if (!flag)
                {
                    pos[i] = temp;
                    i++;
                }
            }

            //Random the AlphaNumericChars
            for (i = 0; i < Length - NonAlphaNumericChars; i++)
                pass[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            //Random the NonAlphaNumericChars
            for (i = Length - NonAlphaNumericChars; i < Length; i++)
                pass[i] = allowedNonAlphaNum[rd.Next(0, allowedNonAlphaNum.Length)];

            //Set the sorted array values by the pos array for the rigth posistion
            char[] sorted = new char[Length];
            for (i = 0; i < Length; i++)
                sorted[i] = pass[pos[i]];

            string Pass = new String(sorted);

            return Pass;
        }
    }
}

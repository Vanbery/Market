using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Market.Models;
using Market.ViewModels.Customers;
using System.Data.SqlClient;

namespace Market.Controllers
{
    [Authorize]
    public class CustomersController : BaseController
    {
        /// <summary>
        /// 客戶資料首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //將關聯物件Product載入
            var model = db.Customers.Include("Product").ToList();
            
            return View(model);
        }

        /// <summary>
        /// 客戶詳細資料頁面
        /// </summary>
        /// <param name="id">客戶編號</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product物件SN為int，轉型後並載入至Customers
            var sn = int.Parse(id);
            Customer customer = db.Customers.Include("Product").Where(m => m.SN == sn).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /// <summary>
        /// 客戶資料新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 客戶資料新增(Post)
        /// </summary>
        /// <param name="customersViewModel">客戶資料ViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersViewModel customersViewModel)
        {
            //將CustomersViewModel的資料轉成Customer
            Customer customer = new Customer() 
            { 
                SN = 0,
                IdNumber = customersViewModel.IdNumber,
                Name = customersViewModel.Name,
                Account = customersViewModel.Account,
                AccountName = customersViewModel.AccountName,
                Address = customersViewModel.Address,
                Bank = customersViewModel.Bank,
                BankCode = customersViewModel.BankCode,
                Boss = customersViewModel.Boss,
                Branch = customersViewModel.Branch,
                BranchCode = customersViewModel.BranchCode,
                Email = customersViewModel.Email,
                Fax = customersViewModel.Fax,
                Phone = customersViewModel.Phone,
                Product = db.Products.Where(m => m.SN.Equals(customersViewModel.Product)).FirstOrDefault()
            };

            if (ModelState.IsValid)
            {
                //寫入db
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        /// <summary>
        /// 客戶資料修改
        /// </summary>
        /// <param name="id">客戶編號</param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product物件SN為int，轉型後並載入至Customers
            var sn = int.Parse(id);
            Customer customer = db.Customers.Include("Product").Where(m => m.SN == sn).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        /// <summary>
        /// 客戶資料修改(Post)
        /// </summary>
        /// <param name="customersViewModel">客戶編號</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersViewModel customersViewModel)
        {
            //將CustomersViewModel的資料轉成Customer
            Customer customer = new Customer()
            {
                SN = customersViewModel.SN,
                IdNumber = customersViewModel.IdNumber,
                Name = customersViewModel.Name,
                Account = customersViewModel.Account,
                AccountName = customersViewModel.AccountName,
                Address = customersViewModel.Address,
                Bank = customersViewModel.Bank,
                BankCode = customersViewModel.BankCode,
                Boss = customersViewModel.Boss,
                Branch = customersViewModel.Branch,
                BranchCode = customersViewModel.BranchCode,
                Email = customersViewModel.Email,
                Fax = customersViewModel.Fax,
                Phone = customersViewModel.Phone,
                Product = db.Products.Where(m => m.SN.Equals(customersViewModel.Product)).FirstOrDefault()
            };

            if (ModelState.IsValid)
            {
                //不知為何無法更新關聯的物件，暫使用SqlCommand進行Update...
                String query = @"update Customers set Product_SN = @psn where SN = @sn";
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                db.Database.ExecuteSqlCommand(query, new SqlParameter("sn", customersViewModel.SN), new SqlParameter("psn", customersViewModel.Product));
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        /// <summary>
        /// 客戶資料刪除
        /// </summary>
        /// <param name="id">客戶編號</param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product物件SN為int，轉型後並載入至Customers
            var sn = int.Parse(id);
            Customer customer = db.Customers.Include("Product").Where(m => m.SN == sn).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        /// <summary>
        /// 客戶資料刪除(Post)
        /// </summary>
        /// <param name="id">客戶編號</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var sn = int.Parse(id);
            Customer customer = db.Customers.Include("Product").Where(m => m.SN == sn).FirstOrDefault();

            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

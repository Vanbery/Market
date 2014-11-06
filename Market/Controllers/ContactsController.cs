using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Market.Models;
using Market.ViewModels.Contacts;
using System.Data.SqlClient;

namespace Market.Controllers
{
    [Authorize]
    public class ContactsController : BaseController
    {
        /// <summary>
        /// 客戶聯絡人首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //將關聯物件Product載入
            var model = db.Contacts.Include("Customer").ToList();

            return View(model);
        }

        /// <summary>
        /// 客戶聯絡人詳細資料
        /// </summary>
        /// <param name="id">客戶聯絡人編號</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer物件SN為int，轉型後並載入至Contacts
            var sn = int.Parse(id);
            Contact contact = db.Contacts.Include("Customer").Where(m => m.SN == sn).FirstOrDefault();
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        /// <summary>
        /// 客戶聯絡人新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 客戶聯絡人新增(post)
        /// </summary>
        /// <param name="contactsViewModel">客戶聯絡人資料ViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactsViewModel contactsViewModel)
        {
            //將ContactsViewModel的資料轉成Contact
            Contact contact = new Contact()
            {
                SN = 0,
                CellPhone = contactsViewModel.CellPhone,
                Email = contactsViewModel.Email,
                Name = contactsViewModel.Name,
                Phone = contactsViewModel.Phone,
                Role = contactsViewModel.Role,
                Customer = db.Customers.Where(m => m.SN == contactsViewModel.Customer).FirstOrDefault()
            };

            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        /// <summary>
        /// 客戶聯絡人資料編輯
        /// </summary>
        /// <param name="id">客戶聯絡人編號</param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer物件SN為int，轉型後並載入至Contacts
            var sn = int.Parse(id);
            Contact contact = db.Contacts.Include("Customer").Where(m => m.SN == sn).FirstOrDefault();
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        /// <summary>
        /// 客戶聯絡人資料編輯(post)
        /// </summary>
        /// <param name="contactsViewModel">客戶聯絡人ViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactsViewModel contactsViewModel)
        {
            //將ContactsViewModel的資料轉成Contact
            Contact contact = new Contact()
            {
                SN = contactsViewModel.SN,
                CellPhone = contactsViewModel.CellPhone,
                Email = contactsViewModel.Email,
                Name = contactsViewModel.Name,
                Phone = contactsViewModel.Phone,
                Role = contactsViewModel.Role,
                Customer = db.Customers.Where(m => m.SN == contactsViewModel.Customer).FirstOrDefault()
            };

            if (ModelState.IsValid)
            {
                //不知為何無法更新關聯的物件，暫使用SqlCommand進行Update...
                String query = @"update Contacts set Customer_SN = @csn where SN = @sn";
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                db.Database.ExecuteSqlCommand(query, new SqlParameter("sn", contactsViewModel.SN), new SqlParameter("csn", contactsViewModel.Customer));
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        /// <summary>
        /// 客戶聯絡人刪除
        /// </summary>
        /// <param name="id">客戶聯絡人編號</param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer物件SN為int，轉型後並載入至Contacts
            var sn = int.Parse(id);
            Contact contact = db.Contacts.Include("Customer").Where(m => m.SN == sn).FirstOrDefault();
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        /// <summary>
        /// 客戶聯絡人刪除(post)
        /// </summary>
        /// <param name="id">客戶聯絡人編號</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //Customer物件SN為int，轉型後並載入至Contacts
            var sn = int.Parse(id);
            Contact contact = db.Contacts.Include("Customer").Where(m => m.SN == sn).FirstOrDefault();

            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <returns>回傳客戶資料</returns>
        public JsonResult GetCustomerData()
        {
            var customer = db.Customers.ToList();

            return Json(customer, JsonRequestBehavior.AllowGet);
        }
    }
}

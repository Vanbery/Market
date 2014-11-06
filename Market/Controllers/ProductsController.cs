using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Market.Models;

namespace Market.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// 商品類別首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        /// <summary>
        /// 商品類別詳細資料
        /// </summary>
        /// <param name="id">商品類別編號</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        /// <summary>
        /// 商品類別新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 商品類別新增(Post)
        /// </summary>
        /// <param name="product">商品類別物件</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        /// <summary>
        /// 商品類別修改
        /// </summary>
        /// <param name="id">商品類別編號</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        /// <summary>
        /// 商品類別修改(Post)
        /// </summary>
        /// <param name="product">商品類別物件</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        /// <summary>
        /// 商品類別刪除
        /// </summary>
        /// <param name="id">商品類別編號</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        /// <summary>
        /// 商品類別刪除
        /// </summary>
        /// <param name="id">商品類別編號</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 取得商品類別資料
        /// </summary>
        /// <returns>回傳商品類別資料</returns>
        public JsonResult GetProductData()
        {
            var product = db.Products.ToList();

            return Json(product, JsonRequestBehavior.AllowGet);
        }

    }
}

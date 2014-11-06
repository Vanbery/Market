using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    /// <summary>
    /// 公用Controller
    /// 各個Controller使用到的Method放置這裡
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// DBContext
        /// </summary>
        public MarketDbContext db = new MarketDbContext();

        /// <summary>
        /// 釋放資源
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
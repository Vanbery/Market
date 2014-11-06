using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    /// <summary>
    /// 供應商品類別
    /// </summary>
    [DisplayName("商品類別")]
    [DisplayColumn("Name")]
    public class Product
    {
        [Key]
        public int SN { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        [Display(Name = "商品纇別名稱")]
        [Required(ErrorMessage = "請輸入商品類別名稱")]
        public String Name { get; set; }
    }
}
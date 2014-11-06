using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Market.Models
{
    [DisplayName("客戶資料")]
    [DisplayColumn("Name")]
    public class Customer
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Key]
        public int SN { get; set; }

        [Required]
        [Display(Name = "公司名稱／姓名")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "統一編號／身份證字號")]
        public String IdNumber { get; set; }

        [Required]
        [Display(Name = "負責人姓名")]
        public String Boss { get; set; }

        [Required]
        [Display(Name = "公司電話")]
        public String Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "公司電子郵件")]
        public String Email { get; set; }

        [Display(Name = "公司傳真")]
        public String Fax { get; set; }

        [Required]
        [Display(Name = "公司地址／戶籍地")]
        public String Address { get; set; }

        [Required]
        [DisplayName("商品類別")]
        public Product Product { get; set; }

        /// <summary>
        /// 帳戶名稱
        /// </summary>
        [Required]
        [Display(Name = "帳戶名稱")]
        public String AccountName { get; set; }

        /// <summary>
        /// 銀行
        /// </summary>
        [Required]
        [Display(Name = "銀行")]
        public String Bank { get; set; }

        /// <summary>
        /// 銀行代碼
        /// </summary>
        [Required]
        [Display(Name = "銀行代碼")]
        public String BankCode { get; set; }

        /// <summary>
        /// 分行
        /// </summary>
        [Required]
        [Display(Name = "分行")]
        public String Branch { get; set; }

        /// <summary>
        /// 分行代碼
        /// </summary>
        [Required]
        [Display(Name = "分行代碼")]
        public String BranchCode { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        [Display(Name = "銀行帳號")]
        public String Account { get; set; }
    }
}
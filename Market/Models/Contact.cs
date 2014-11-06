using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    /// <summary>
    /// 客戶聯絡人
    /// </summary>
    [DisplayName("客戶聯絡人")]
    [DisplayColumn("Name")]
    public class Contact
    {
        [Key]
        public int SN { get; set; }

        [Required]
        [Display(Name = "客戶")]
        public Customer Customer { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [Required]
        [Display(Name = "角色")]
        public String Role { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [Display(Name = "姓名")]
        public String Name { get; set; }

        /// <summary>
        /// 電子郵件
        /// </summary>
        [Required]
        [Display(Name = "電子郵件")]
        public String Email { get; set; }

        /// <summary>
        /// 行動電話
        /// </summary>
        [Display(Name = "行動電話")]
        public String CellPhone { get; set; }

        /// <summary>
        /// 聯絡電話
        /// </summary>
        [Required]
        [Display(Name = "聯絡電話")]
        public String Phone { get; set; }
    }
}
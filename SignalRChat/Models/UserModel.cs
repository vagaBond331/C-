using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Web;

namespace OlympiaApp.Models
{
    public class UserModel
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string SDT { get; set; }
    }

    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}

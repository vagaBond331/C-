using System.ComponentModel.DataAnnotations;
using System;

namespace Olympia.Models
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

    public class Player
    {
        public int STT { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int pointR1 { get; set; }
        public int pointR2 { get; set; }
        public int pointR3 { get; set; }
        public int pointR4 { get; set; }

        public Player()
        {
            STT = 1;
            id = "unknow";
            name = "unknow";
            pointR1 = 0;
            pointR2 = 0;
            pointR3 = 0;
            pointR4 = 0;
        }
    }

    public class ListPlayer
    {
        public int num { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player Player3 { get; set; }
        public Player Player4 { get; set; }

        public ListPlayer()
        {
            this.num = 4;
            Player1 = new Player();
            Player2 = new Player();
            Player3 = new Player();
            Player4 = new Player();
        }
    }
}

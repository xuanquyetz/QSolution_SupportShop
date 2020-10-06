using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.ViewModels.System.Users
{
   public class RegisterRequest
    {
        public string Ho { set; get; }
        public string Ten { set; get; }
        public DateTime NgaySinh { set; get; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }
    }
}

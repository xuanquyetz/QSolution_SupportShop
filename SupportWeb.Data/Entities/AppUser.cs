using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Entities
{
   public class AppUser: IdentityUser<Guid>
    {
        public string Ho { set; get; }
        public string Ten { set; get; }
        public DateTime NgaySinh { set; get; }
    }
}

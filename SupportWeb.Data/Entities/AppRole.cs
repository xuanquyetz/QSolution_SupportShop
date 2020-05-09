using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWeb.Data.Entities
{
   public class AppRole:IdentityRole<Guid>
    {
       public string GhiChu { set; get; }
    }
}

using SupportWeb.ViewModels.Common;
using SupportWeb.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportWeb.Application.System.Users
{
   public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}

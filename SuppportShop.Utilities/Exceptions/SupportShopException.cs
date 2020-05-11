using System;
using System.Collections.Generic;
using System.Text;

namespace SuppportShop.Utilities.Exceptions
{
   public class SupportShopException:Exception
    {
        public SupportShopException()
        {

        }
        public SupportShopException(string message)
            : base(message)
        {

        }
        public SupportShopException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

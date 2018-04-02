using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace app
{
    public class Util : IUtil
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Util(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        const string CART_KEY = "cartKey";
        public string GetCartId()
        {
            string cartId;

            if (_httpContextAccessor.HttpContext.Session.Keys.Any(key => key == CART_KEY))
            {
                cartId = _httpContextAccessor.HttpContext.Session.GetString(CART_KEY); 
            }
            else
            {
                cartId = Guid.NewGuid().ToString();
                _httpContextAccessor.HttpContext.Session.SetString(CART_KEY, cartId);
            }

            return cartId;
        }
    }
}
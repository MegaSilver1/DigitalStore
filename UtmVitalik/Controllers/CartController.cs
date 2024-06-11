using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UtmVitalik.BusinessLogic.DB;

namespace UtmVitalik.Controllers
{
    public class CartController : Controller
    {
        private Dictionary<int, int> cartItems = new Dictionary<int, int>();

        public ActionResult Cart()
        {
            // Логика для отображения содержимого корзины
            int itemCount = cartItems.Count; // Пример получения количества товаров в корзине

            // Создаем объект модели для передачи данных в представление
            var model = new CartViewModel()
            {
                CartItemCount = itemCount,
                CartItems = cartItems
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            try
            {
                if (cartItems.ContainsKey(productId))
                {
                    cartItems[productId]++;
                }
                else
                {
                    cartItems.Add(productId, 1);
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }

   
}
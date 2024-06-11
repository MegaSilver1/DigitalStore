using System.Collections.Generic;

namespace UtmVitalik.BusinessLogic.DB
{
    public class CartViewModel
    {
        public int CartItemCount { get; set; }
        public Dictionary<int, int> CartItems { get; set; }
    }
}
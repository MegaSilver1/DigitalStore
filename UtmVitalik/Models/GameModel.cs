using System.Collections;
using System.Collections.Generic;

namespace UtmVitalik.BusinessLogic.DB
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public IEnumerable<object> Any()
        {
            throw new System.NotImplementedException();
        }
    }
}
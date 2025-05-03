using System.Collections.Generic;
using UnityEngine;

namespace Unchord
{
    public class Product : ScriptableObject
    {
        public int id;
        public int maxStockCount;
        public List<ProductPricePolicy> productPricePolicies;
    }
}
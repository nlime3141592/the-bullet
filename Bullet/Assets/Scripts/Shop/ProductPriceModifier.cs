using System;

namespace Unchord
{
    public class ProductPriceModifier : IComparable<ProductPriceModifier>
    {
        public readonly float value;
        public readonly ProductPriceModifyingType modifyingType;
        public readonly int order;
        public readonly object source;

        public ProductPriceModifier(float value, ProductPriceModifyingType modifyingType, int order, object source)
        {
            this.value = value;
            this.modifyingType = modifyingType;
            this.order = order;
            this.source = source;
        }

        int IComparable<ProductPriceModifier>.CompareTo(ProductPriceModifier other)
        {
            if (this.order < other.order)
                return 1;
            else if (this.order > other.order)
                return -1;
            else if (this.modifyingType < other.modifyingType)
                return 1;
            else if (this.modifyingType > other.modifyingType)
                return -1;
            else
                return 0;
        }
    }
}
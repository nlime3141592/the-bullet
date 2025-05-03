using System;
using System.Collections.Generic;

namespace Unchord
{
    [Serializable]
    public class ProductPricePolicy
    {
        public float FinalPrice
        {
            get
            {
                if (_shouldUpdate)
                {
                    _shouldUpdate = false;
                    _finalPrice = CalculateFinalPrice();
                }

                return _finalPrice;
            }
        }

        public readonly int billType;
        public readonly float basePrice;

        private List<ProductPriceModifier> _modifiers;
        private bool _shouldUpdate;
        private float _finalPrice;

        public ProductPricePolicy(int billType, float basePrice)
        {
            this.billType = billType;
            this.basePrice = basePrice;

            _modifiers = new List<ProductPriceModifier>(2);
            _shouldUpdate = false;
            _finalPrice = basePrice;
        }

        public void AddModifier(ProductPriceModifier modifier)
        {
            if (_modifiers.Contains(modifier))
                return;

            _modifiers.Add(modifier);
            _modifiers.Sort();
            _shouldUpdate = true;
        }

        public void RemoveModifier(ProductPriceModifier modifier)
        {
            if (!_modifiers.Contains(modifier))
                return;

            _modifiers.Remove(modifier);
            _modifiers.Sort();
            _shouldUpdate = true;
        }

        public void RemoveModifierBySource(object source)
        {
            bool removed = false;

            for (int i = _modifiers.Count - 1; i >= 0; --i)
            {
                if (_modifiers[i].source == source)
                {
                    _modifiers.RemoveAt(i);
                    removed = true;
                }
            }

            _shouldUpdate = removed;
        }

        private float CalculateFinalPrice()
        {
            float finalPrice = basePrice;

            int currentOrder = 0;

            float flatSum = 0.0f;
            float percAdd = 1.0f;
            float percMul = 1.0f;

            if (_modifiers.Count > 0)
                currentOrder = _modifiers[_modifiers.Count - 1].order;

            for (int i = _modifiers.Count - 1; i >= 0; --i)
            {
                if (_modifiers[i].order != currentOrder)
                {
                    flatSum = 0.0f;
                    percAdd = 1.0f;
                    percMul = 1.0f;
                }

                switch (_modifiers[i].modifyingType)
                {
                    case ProductPriceModifyingType.Flat:
                        flatSum += _modifiers[i].value;
                        break;
                    case ProductPriceModifyingType.PercentAdd:
                        percAdd += _modifiers[i].value;
                        break;
                    case ProductPriceModifyingType.PercentMul:
                        percMul *= (1.0f + _modifiers[i].value);
                        break;
                }

                finalPrice += flatSum * percAdd * percMul;
            }

            return finalPrice;
        }
    }
}
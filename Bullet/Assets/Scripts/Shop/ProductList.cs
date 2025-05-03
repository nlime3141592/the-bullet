using System;
using System.Collections.Generic;

namespace Unchord
{
    public class ProductList : List<Product>
    {
        public List<Product> LoadedProducts { get; private set; }
        public bool IsValidPageLoaded { get; private set; }
        public bool IsLastPageLoaded { get; private set; }
        public int LoadedPageNumber { get; private set; }
        public int LoadedPageSize { get; private set; }

        public ProductList()
        {
            LoadedProducts = new List<Product>(16);
        }

        public List<Product> LoadProducts(int pageNumber, int pageSize)
        {
            UnityEngine.Debug.Assert(pageNumber > 0, "page number should begin at 1.");

            int start = (pageNumber - 1) * pageSize;
            int end = Math.Min(base.Count, pageNumber * pageSize);

            LoadedProducts.Clear();

            for (int i = 0; i < end - start; ++i)
            {
                LoadedProducts.Add(base[start + i]);
            }

            LoadedPageNumber = pageNumber;
            LoadedPageSize = pageSize;

            IsValidPageLoaded = start < base.Count;
            IsLastPageLoaded = end == base.Count;

            return LoadedProducts;
        }
    }
}
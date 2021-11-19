using System;

namespace NamespaceProduct
{
    class Tofu : Product
    {
        protected double quantity;
        protected string seasoning;

        protected Tofu(double quantity, string seasoning)
        {
            this.quantity = quantity;
            this.seasoning = seasoning;
        }
    }
}

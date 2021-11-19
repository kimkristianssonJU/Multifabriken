using System;
using StaticClass;

namespace NamespaceProduct
{
    class Candy : Product
    {
        protected Flavours flavour;
        protected int amount;
        protected Candy(Flavours flavour, int amount)
        {
            this.flavour = flavour;
            this.amount = amount;
        }
    }
}

using System;

namespace NamespaceProduct
{
    class Product
    {
        protected Product() { }
        // Används för att kategorisera i handelslistan (Session.shoppingCart) 
        public virtual string ProductType
        {
            get
            {
                return "Product Name Placeholder";
            }
        }
        // Skriver ut en visuell representation av objektet
        public virtual void PrintInformation()
        {
            Console.WriteLine("Product Info Placeholder");
        }
    }
}

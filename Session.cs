using System;
using System.Collections.Generic;
using NamespaceProduct;

namespace multifabriken_kimkristianssonJU
{
    class Session
    {
        public Dictionary<string, List<Product>> shoppingCart = new Dictionary<string, List<Product>>();

        // Lägger till nya objekt i listan över de produkter användaren har beställt
        public void AddToCart(Product product)
        {
            if (shoppingCart.ContainsKey(product.ProductType))
            {
                shoppingCart[product.ProductType].Add(product);
            }
            else
            {
                shoppingCart.Add(product.ProductType, new List<Product>());
                shoppingCart[product.ProductType].Add(product);
            }
        }

        // Skriver ut allt som användaren har beställt
        public void PrintOutCart()
        {
            Console.Clear();
            if (shoppingCart.Count > 0)
            {
                foreach (KeyValuePair<string, List<Product>> entry in shoppingCart)
                {
                    Console.WriteLine($"===== {entry.Key} =====");

                    foreach (Product product in entry.Value)
                    {
                        product.PrintInformation();
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($@"Här var det tomt! ¯\_(o.O)_/¯");
                Console.WriteLine($@"Se till att shoppa lite!{Environment.NewLine}");
            }

            Console.Write(@$"[Tryck vad som helst för att gå vidare]");
            Console.ReadKey();
        }
    }
}

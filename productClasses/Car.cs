using System;
using StaticClass;

namespace NamespaceProduct
{
    class Car : Product
    {
        protected string brand;
        protected Colors color;
        protected string regNumber;
        protected Car(string brand, Colors color, string regNumber)
        {
            this.brand = brand;
            this.color = color;
            this.regNumber = regNumber;
        }
    }
}

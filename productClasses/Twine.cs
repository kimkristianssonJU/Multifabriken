using System;
using StaticClass;

namespace NamespaceProduct
{
    class Twine : Product
    {
        protected double length;
        protected Colors color;
        protected Twine(double length, Colors color)
        {
            this.length = length;
            this.color = color;
        }
    }
}

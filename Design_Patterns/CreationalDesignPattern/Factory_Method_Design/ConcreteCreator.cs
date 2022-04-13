using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalDesignPattern.Factory_Method_Design
{
    class ConcreteCreator
    {
        public class MoneyBackFactory : CreditCardFactory
        {
            protected override CreditCard MakeProduct()
            {
                CreditCard product = new MoneyBack();
                return product;
            }
        }
        public class PlatinumFactory : CreditCardFactory
        {
            protected override CreditCard MakeProduct()
            {
                CreditCard product = new Platinum();
                return product;
            }
        }
        public class TitaniumFactory : CreditCardFactory
        {
            protected override CreditCard MakeProduct()
            {
                CreditCard product = new Titanium();
                return product;
            }
        }
    }
}

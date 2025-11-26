using System;
using Delivery.Utils;
using Delivery.Core;

namespace Delivery.Pricing
{
    public class TaxStrategy : IPricingStrategy
    {
        private readonly decimal _taxRate;

        public TaxStrategy(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public Money Apply(Order order, Money current)
        {
            var tax = new Money(current.Amount * _taxRate);
            return new Money(current.Amount + tax.Amount);
        }
    }
}

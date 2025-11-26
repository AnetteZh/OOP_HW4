namespace Delivery.Utils
{
  // обертка для денег, чтобы было удобно расширять и менять
    public readonly struct Money
    {
        public decimal Amount { get; }

        public Money(decimal amount) => Amount = decimal.Round(amount, 2);

        public static Money operator +(Money a, Money b) => new Money(a.Amount + b.Amount);
        public static Money operator -(Money a, Money b) => new Money(a.Amount - b.Amount);
        public static Money operator *(Money a, decimal factor) => new Money(a.Amount * factor);
        public override string ToString() => $"{Amount:F2}";

        public static Money Zero => new Money(0m);
    }
}

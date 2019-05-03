
namespace BankAccount
{
    public class Amount
    {
        public double Value { get; private set; }

        public Amount(double amountValue)
        {
            Value = amountValue;
        }

        public void IncreaseAmount(Amount amount)
        {
            Value += amount.Value;
        }

        public void DecreaseAmount(Amount amount)
        {
            Value -= amount.Value;
        }

        public bool isPositive()
        {
            return Value > 0;
        }

        public bool isNegative()
        {
            return Value < 0;
        }
    }
}

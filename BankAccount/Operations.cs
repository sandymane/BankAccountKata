using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class Operations
    {
        public List<Operation> _operations { get; }


        public Operations()
        {
            _operations = new List<Operation>();
        }

        public void AddOperation(Operation operation)
        {
            _operations.Add(operation);
        }

        public int GetCount()
        {
            return _operations.Count;
        }

        public int GetCountOf<T>() where T : Operation
        {
            return _operations.OfType<T>().Count();
        }

        public double ComputeTotalOf<T>() where T : Operation
        {
            return _operations.OfType<T>().Sum(b => b.Amount.Value);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            _operations.OrderByDescending(b => b.Date)
               .ToList()
               .ForEach(b => stringBuilder.AppendLine(b.ToString()));

            return stringBuilder.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Accounting
{
    class Worker : IPayable
    {
        public Worker(string firstName, string lastName, decimal cost)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Cost = cost;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }
    }

    class Expenditure : IPayable
    {
        public Expenditure(string expence, decimal cost)
        {
            this.Expence = expence;
            this.Cost = cost;
        }

        public string Expence { get; set; }
        public decimal Cost { get; set; }
    }

    public class Accounting
    {
        static void Main(string[] args)
        {
            List<IPayable> receipt = new List<IPayable>()
            {
                new Worker("Tosho", "Toshev", 950),
                new Worker("Sasho", "Toshev", 1050),
                new Worker("Tosho", "Toshev", 950),
                new Worker("Sasho", "Toshev", 950),
                new Expenditure("Printer paper", 250),
                new Expenditure("Fax paper", 150),
                new Expenditure("Markers", 50)
            };

            var paymentsPerWorker = receipt.Where(e => e is Worker)
                .GroupBy(w => (w as Worker).FirstName)
                .Select(n => n.Sum(w => w.Cost));

            foreach (var item in paymentsPerWorker)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

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

    class Material : IPayable
    {
        public Material(string expence, decimal cost)
        {
            this.Name = expence;
            this.Cost = cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
    }

    public class Accounting
    {
        static void Main(string[] args)
        {
            List<IPayable> payments = new List<IPayable>()
            {
                new Worker("Max", "Smith", 950),
                new Worker("Sam", "Wise", 1050),
                new Worker("Max", "Smith", 950),
                new Worker("Sam", "Wise", 950),
                new Worker("Sam", "Tylor", 950),
                new Worker("Tom", "Ton", 1950),
                new Worker("Sam", "Donovan", 950),
                new Material("Printer paper", 250),
                new Material("Fax paper", 150),
                new Material("Markers", 50)
            };

            payments.Where(e => e is Worker)
                .OrderBy(w => ((Worker)w).FirstName)
                .ThenBy(w => ((Worker)w).LastName)
                .GroupBy(w => ((Worker)w).FirstName + " " + ((Worker)w).LastName)
                //.OrderByDescending(g => g.Count()) // Times payed
                //.ThenByDescending(g => g.Sum(w => w.Cost))
                .ToDictionary(g => g.Key, g => g.Sum(w => w.Cost))
                .OrderByDescending(w => w.Value)
                .ThenBy(w => w.Key)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
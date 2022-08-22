using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee berat = new Employee { Name = "Berat Eliaçık" };
            Employee damla = new Employee { Name = "Damla Eliaçık" };

            berat.AddSubordinate(damla);

            Employee arife = new Employee { Name = "Arife Dal" };
            berat.AddSubordinate(arife);

            Contractor ali = new Contractor { Name = "Ali" };
            arife.AddSubordinate(ali);

            Employee busra = new Employee { Name = "Büşra Eliaçık" };
            damla.AddSubordinate(busra);

            Console.WriteLine(berat.Name);
            foreach (Employee manager in berat)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
         string Name { get; set; }

    }

    class Contractor:IPerson
    {
        public string Name { get; set; }
    }

    class Employee:IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

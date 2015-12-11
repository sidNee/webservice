using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTSample
{
    public static class CustomerRepository
    {
        // static (keine Instanz, ist immer da); readonly(kann nicht zugewiesen werden), Dictionary(Map(HashTable)
        private static readonly Dictionary<int, Customer> s_Customers = new Dictionary<int, Customer>();

        static CustomerRepository()
        {
            s_Customers.Add(
                1,
                new Customer
                {
                    Id = 1,
                    Name = "Peter Aurin",
                    LastContact = new DateTime(1999, 12, 5, 10, 30, 0)
                });
            s_Customers.Add(
                2,
                new Customer
                {
                    Id = 2,
                    Name = "Denis Anderwald",
                    LastContact = new DateTime(2006, 9, 23, 10, 30, 0)
                });
            s_Customers.Add(
                3,
                new Customer
                {
                    Id = 3,
                    Name = "Jacob Klimes",
                    LastContact = new DateTime(2014, 1, 5, 10, 30, 0)
                });
            s_Customers.Add(
                4,
                new Customer
                {
                    Id = 4,
                    Name = "Gabi Peters"
                });
        }

        public static IEnumerable<Customer> GetAll()
        {
            return new List<Customer>(s_Customers.Values);
        }

        public static Customer Get(int id)
        {
            //Exception freundlichere Variante
            Customer customer;
            s_Customers.TryGetValue(id, out customer);
            return customer;
        }

        //CRUD-Operationen
        public static void Add(Customer c)
        {
            s_Customers.Add(c.Id, c);
        }

        public static void Update(Customer c)
        {
            s_Customers[c.Id] = c;
        }

        public static void Delete(int id)
        {
            s_Customers.Remove(id);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastContact { get; set; }
    }
}

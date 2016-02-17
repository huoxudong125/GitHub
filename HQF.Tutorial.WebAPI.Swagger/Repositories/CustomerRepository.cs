using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using HQF.Tutorial.WebAPI.Swagger.Models;

namespace HQF.Tutorial.WebAPI.Swagger.Repositories
{
    public class CustomerRepository
    {
        private static IEnumerable<Customer> Customers { get; set; }
        private static bool _loaded = false;
        public static bool LoadCustomers()
        {
            Customers=new List<Customer>()
            {
                new Customer()
                {
                    FirstName = "Li",
                    LastName = "huo",
                    City = "Beijing"
                },
                 new Customer()
                {
                    FirstName = "Li",
                    LastName = "LI",
                    City = "Beijing"
                }
            };
            //string path = System.String.Format(@"{0}App_Data\us-500.csv", System.AppDomain.CurrentDomain.BaseDirectory);
            //using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //{
            //    try
            //    {
                    //var cs = new CsvSerializer<Customer>()
                    //{
                    //    UseTextQualifier = false,
                    //    Separator = ',',
                    //    RowSeparator = "\n",
                    //    UseLineNumbers = false,
                    //    ColumnsContainedInHeader = true
                    //};

                    //Customers = cs.Deserialize(stream);
                    _loaded = true;
            //    }
            //    catch
            //    { }
            //}

            return _loaded;
        }
        public static IEnumerable<Customer> GetCustomers()
        {
            if (_loaded)
            {
                return Customers;
            }

            throw new Exception("An error ocured while loading the List of customers");
        }

        public static IEnumerable<Customer> GetCustomers(int page, int offset)
        {
            if (_loaded)
            {
                return Customers.Skip((page - 1) * offset).Take(offset);
            }

            throw new Exception("An error ocured while loading the List of customers");
        }

        internal static object GetCustomers(string email)
        {
            return Customers.SingleOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        internal static void AddCustomer(Customer customer)
        {
            var list = Customers.ToList();
            list.Add(customer);

            Customers = list.AsEnumerable();
        }

        internal static void RemoveCustomer(Customer customer)
        {
            var list = Customers.ToList();
            list.Remove(customer);

            Customers = list.AsEnumerable();
        }
    }
}
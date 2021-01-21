using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c =>
            {
                decimal sumOfAllOrders = c.Orders.Sum(order => order.Total);

                if (sumOfAllOrders > limit)
                {
                    return true;
                }

                return false;
            });
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            var result = customers.Select(customer =>
            {
                return  (customer,
                    suppliers.Where(supplier => supplier.Country == customer.Country
                        && supplier.City == customer.City));
            });

            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            var result =
                customers.Select(customer =>
                {
                    return (customer,
                        suppliers.GroupBy(supplier => new { Country = supplier.Country, City = supplier.City})
                            .Where(supplierGroup => supplierGroup.Key.Country == customer.Country &&
                                supplierGroup.Key.City == customer.City)
                            .SelectMany(supplierGroup => supplierGroup));
                });

            return result;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(customer => customer.Orders.Any(order => order.Total > limit));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            return customers.Select(customer => (customer,
                customer.Orders.Select(order => order.OrderDate).Min()));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            return customers.Select(customer => (customer,
                customer.Orders.Select(order => order.OrderDate).Min()))
                .OrderBy(c => c.Item2.Year)
                .ThenBy(c => c.Item2.Month)
                .ThenByDescending(c => c.customer.Orders.Sum(order => order.Total))
                .ThenBy(c => c.customer.CompanyName);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            return customers.Where(customer => customer.PostalCode.Any(Char.IsLetter) ||
                customer.Region == null || ! customer.Phone.StartsWith('('));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            throw new NotImplementedException();
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            throw new NotImplementedException();
        }
    }
}

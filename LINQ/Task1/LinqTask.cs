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
            var result = new List<Linq7CategoryGroup>();

            var categoryGroups = products.GroupBy(product => product.Category);

            foreach (var categoryGroup in categoryGroups)
            {
                var linq7CategoryGroup = new Linq7CategoryGroup
                {
                    Category = categoryGroup.Key,
                    UnitsInStockGroup = new List<Linq7UnitsInStockGroup>()
                };

                var unitsInStockGroups = categoryGroup.GroupBy(group => group.UnitsInStock);
                
                foreach (var unitsInStockGroup in unitsInStockGroups)
                {
                    var linq7UnitsInStockGroup = new Linq7UnitsInStockGroup
                    {
                        UnitsInStock = unitsInStockGroup.Key,
                        Prices = unitsInStockGroup.Select(group => group.UnitPrice).OrderBy(unitPrice => unitPrice)
                    };

                    linq7CategoryGroup.UnitsInStockGroup.ToList().Add(linq7UnitsInStockGroup);
                }

                result.Add(linq7CategoryGroup);
            }

            return result.AsEnumerable<Linq7CategoryGroup>();
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            var cheapProducts = products.Where(product => product.UnitPrice > 0 && product.UnitPrice <= cheap);
            var middleProducts = products.Where(product => product.UnitPrice > cheap && product.UnitPrice <= middle);
            var expensiveProducts = products.Where(product => product.UnitPrice > middle && product.UnitPrice <= expensive);

            var result = new List<(decimal, IEnumerable<Product>)>();
            result.Add((cheap, cheapProducts));
            result.Add((middle, middleProducts));
            result.Add((expensive, expensiveProducts));

            return result.AsEnumerable();
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

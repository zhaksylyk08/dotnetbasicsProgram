using Task1.DoNotChange;

namespace Task1.Tests.Entities
{
    [ImportConstructor]
    public class CustomerBLL
    {
        public CustomerBLL(ICustomerDAL dal, Logger logger)
        { }
    }

}

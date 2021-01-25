using Task1.DoNotChange;

namespace Task1.Tests.Entities
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    { }
}

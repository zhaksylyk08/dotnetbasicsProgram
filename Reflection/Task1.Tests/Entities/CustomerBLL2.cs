using Task1.DoNotChange;

namespace Task1.Tests.Entities
{
    public class CustomerBLL2
    {
        [Import]
        public ICustomerDAL CustomerDAL { get; set; }
        [Import]
        public Logger Logger { get; set; }
    }

}

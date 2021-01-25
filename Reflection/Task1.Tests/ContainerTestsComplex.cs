using System.Reflection;
using NUnit.Framework;
using Task1.Tests.Entities;

namespace Task1.Tests
{
    [TestFixture]
    public class ContainerTestsComplex
    {
        private Container container;

        [SetUp]
        public void Setup()
        {
            container = new Container();
        }

        [Test]
        public void AddTypeT_TryRegisterLoggerTwice_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddType(typeof(Logger));
                container.AddType(typeof(Logger));
                container.Get<Logger>();
            }, Throws.Exception);
        }

        [Test]
        public void AddTypeT_TryRegisterInterface_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddType(typeof(ICustomerDAL));
                container.Get<ICustomerDAL>();
            }, Throws.Exception);
        }

        [Test]
        public void AddTypeTandTBase_SingleCustomerDALRegistration_ReturnCustomerDAL()
        {
            container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

            var customerDAL = container.Get<CustomerDAL>();

            Assert.That(customerDAL, Is.Not.Null);
            Assert.That(customerDAL, Is.InstanceOf<CustomerDAL>());
        }

        [Test]
        public void AddTypeTandTBase_TryRegisterICustomerDALTwice_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));
                container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));
                container.Get<ICustomerDAL>();
            }, Throws.Exception);
        }

        [Test]
        public void AddTypeTandTBase_TryRegisterInterface_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddType(typeof(ICustomerDAL), typeof(ICustomerDAL));
                container.Get<ICustomerDAL>();
            }, Throws.Exception);
        }

        [Test]
        public void AddAssembly_AssemblyWithDependenciesTwice_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddAssembly(Assembly.GetExecutingAssembly());
                container.AddAssembly(Assembly.GetExecutingAssembly());
                container.Get<ICustomerDAL>();
            }, Throws.Exception);
        }

        [Test]
        public void AddAssembly_AssemblyWithoutDependencies_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddAssembly(TestHelper.GetTask1Assembly());
                container.Get<ICustomerDAL>();
            }, Throws.Exception);
        }

        [Test]
        public void AddAssembly_AssemblyWithNotEnoughDependencies_ThrowsError()
        {
            Assert.That(() =>
            {
                container.AddAssembly(Assembly.GetExecutingAssembly());
                container.Get<CustomerBLL3>();
            }, Throws.Exception);
        }
    }
}


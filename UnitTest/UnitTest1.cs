using RZA_sly.Components;
using RZA_sly.Services;
using RZA_sly.Utilities;
using RZA_sly.Models;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    public class Tests
    {
        private TlSlyRzaContext _context;
        private CustomerService _customerService;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<TlSlyRzaContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new TlSlyRzaContext(options);
            _customerService = new CustomerService(_context);
        }
        [Test]
        public async Task Test1()
        {
            Customer tempCustomer = new Customer()
            {
                Username = "admin",
                Password = "admin"
            };
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == "admin");
            Assert.NotNull(result);
        }
        #region hidden
        [Test]
        public async Task Test2()
        {
            Customer tempCustomer = new Customer();
            tempCustomer.Username = "admin";
            tempCustomer.Password = PasswordUtils.HashPassword("admin");
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == "not admin");
            Assert.Null(result);
        }
        [Test]
        public async Task Test3()
        {
            Customer tempCustomer = new Customer();
            tempCustomer.Username = "admin";
            tempCustomer.Password = PasswordUtils.HashPassword("admin");
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _customerService.LogIn(tempCustomer);
            Assert.NotNull(result);
        }
        [Test]
        public async Task Test4()
        {
            Customer tempCustomer = new Customer();
            tempCustomer.Username = "admin";
            tempCustomer.Password = PasswordUtils.HashPassword("admin");
            await _customerService.AddCustomerAsync(tempCustomer);
            tempCustomer.Username = "not admin";
            var result = await _customerService.LogIn(tempCustomer);
            Assert.Null(result);
        }
        #endregion
        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }
    }
}
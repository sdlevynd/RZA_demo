using RZA_sly.Components;
using RZA_sly.Services;
using RZA_sly.Utilities;
using RZA_sly.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Tests
    {
        private TlSlyRzaContext _context;
        private CustomerService _customerService;

        [SetUp]
        public void SetUp()
        {
            //// Configure the in-memory database
            //var options = new DbContextOptionsBuilder<TlSlyRzaContext>()
            //    .UseInMemoryDatabase(databaseName: "TestDatabase")
            //    .Options;

            //_context = new TlSlyRzaContext(options);
            //_customerService = new CustomerService(_context);

            //// Seed some initial data if needed
            //_context.MyDataTable.Add(new MyDataModel { Id = 1, Name = "Initial Data" });
            //_dbContext.SaveChanges();
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    _dbContext.Dispose();
        //}
    }
}
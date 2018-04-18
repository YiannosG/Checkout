using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkout.Business;
using Checkout.Controllers;
using Checkout.Entities;
using Checkout.Models;
using Checkout.Services;
using Moq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Api;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Checkout.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IDataContext> _mockContextService;
        private HomeController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockContextService = new Mock<IDataContext>();
            _controller = new HomeController(_mockContextService.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockContextService.VerifyAll();
        }

       

        [TestMethod]
        public void Index_ExpectViewResultReturned()
        {
            var stubItems = new List<Item>
            {
                new Item()
                {
                    Id = 1,
                    Name = "A",
                    Price = 50,
                    OfferItemCount = 3,
                    OfferPrice = 130
                },
                new Item()
                {
                    Id = 2,
                    Name = "B",
                    Price = 30,
                    OfferItemCount = 2,
                    OfferPrice = 45
                },
                new Item()
                {
                    Id = 3,
                    Name = "C",
                    Price = 20,
                    OfferItemCount = 0,
                    OfferPrice = 0
                },
                 new Item()
                {
                    Id = 4,
                    Name = "D",
                    Price = 15,
                    OfferItemCount = 0,
                    OfferPrice = 0
                }
            };

            // 13
            _mockContextService.Setup(x => x.GetAllItems()).Returns(stubItems);

            // 14
            var expectedModel = new List<ItemViewModel>();
            foreach (var stubItem in stubItems)
            {
                expectedModel.Add(new ItemViewModel()
                {
                    Id = stubItem.Id,
                    Name = stubItem.Name,
                    Price = stubItem.Price,
                    OfferItemCount = stubItem.OfferItemCount,
                    OfferPrice = stubItem.OfferPrice
                });
            }

            // 15
            var result = _controller.Index() as ViewResult;

            // 16
            if (result != null)
            {
                var actualModel = result.Model as List<ItemViewModel>;

                // 17
                for (int i = 0; i < expectedModel.Count; i++)
                {
                    if (actualModel != null)
                    {
                        Assert.AreEqual(expectedModel[i].Id, actualModel[i].Id);
                        Assert.AreEqual(expectedModel[i].Name, actualModel[i].Name);
                        Assert.AreEqual(expectedModel[i].Price, actualModel[i].Price);
                        Assert.AreEqual(expectedModel[i].OfferItemCount, actualModel[i].OfferItemCount);
                        Assert.AreEqual(expectedModel[i].OfferPrice, actualModel[i].OfferPrice);
                    }
                }
            }
        }

        [TestCase(1, 50)]
        [TestCase(2, 100)]
        public void One_A_should_give_a_total_of_50(int numberOfAs, int expectedTotal )
        {
            CheckOut checkOut = new CheckOut();
            int totalPrice = checkOut.CalculateTotal(numberOfAs);
            Assert.IsTrue(totalPrice == expectedTotal);
        }

        [TestCase("A", 50)]
        [TestCase("AAA", 130)]
        [TestCase("AAAABBBBBCCD", 355)]
        public void A_String_Of_Items_should_give_the_correct_total(string items, int expectedTotal)
        {
            CheckOut checkOut = new CheckOut();
            
            int totalPrice = checkOut.Scan(items);
            Assert.IsTrue(totalPrice == expectedTotal);
        }

    }
   
}

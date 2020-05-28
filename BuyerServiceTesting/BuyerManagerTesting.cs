using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using BuyerService.Manager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerServiceTesting
{
    [TestFixture]
    public class BuyerManagerTesting
    {
        IBuyerManager iBuyerManager;
        private Mock<IBuyerRepository> mockBuyerManager;

        [SetUp]
        public void SetUp()
        {
            mockBuyerManager = new Mock<IBuyerRepository>();
            iBuyerManager = new BuyerManager(mockBuyerManager.Object);
        }

        [TearDown]
        public void TearDown()
        {
            iBuyerManager = null;
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase(4526)]
        [TestCase(3252)]
        [Description("testing buyer Profile")]
        public async Task BuyerProfile_Successfull(int buyerId)
        {
            try
            {
                BuyerData buyer = new BuyerData();
                var mock = new Mock<IBuyerRepository>();
                mock.Setup(x => x.GetBuyerProfile(buyerId)).ReturnsAsync(buyer);
                BuyerManager buyerManager = new BuyerManager(mock.Object);
                var result = await buyerManager.GetBuyerProfile(buyerId);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [TestCase(458)]
        [TestCase(322)]
        [Description("testing buyer Profile failure")]
        public async Task BuyerProfile_UnSuccessfull(int buyerId)
        {
            try
            {
                mockBuyerManager.Setup(x => x.GetBuyerProfile(buyerId));
                var result = await iBuyerManager.GetBuyerProfile(buyerId);
                Assert.IsNull(result, "Invalid User");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing buyer edit Profile")]
        public async Task EditBuyerProfile_Successfull()
        {
            try
            {
                BuyerData buyer = new BuyerData() { buyerId = 6743, userName = "anvi", password = "abcdefg@", emailId = "anvi@gmail.com", mobileNo = "9873452567", dateTime = System.DateTime.Now };
                mockBuyerManager.Setup(x => x.EditBuyerProfile(buyer)).ReturnsAsync(true);
                var result = await iBuyerManager.EditBuyerProfile(buyer);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Testing buyer profile
        /// </summary>
        [Test]
        [Description("testing buyer edit Profile")]
        public async Task EditBuyerProfile_UnSuccessfull()
        {
            try
            {
                BuyerData buyer = new BuyerData() { buyerId = 674, userName = "anvi", password = "abcdefg@", emailId = "anvi@gmail.com", mobileNo = "9873452567", dateTime = System.DateTime.Now };
                mockBuyerManager.Setup(x => x.EditBuyerProfile(buyer)).ReturnsAsync(false);
                var result = await iBuyerManager.EditBuyerProfile(buyer);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

    }
}

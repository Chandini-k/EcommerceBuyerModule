using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserService.Manager;

namespace UserServiceTesting
{
    public class UserManagerTesting
    {
        IUserManager userManager;
        private Mock<IUserRepository> mockUserManager;
        [SetUp]
        public void SetUp()
        {
            mockUserManager = new Mock<IUserRepository>();
            userManager = new UserManager(mockUserManager.Object);
        }

        [TearDown]
        public void TearDown()
        {
            userManager = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase(7388, "mango", "abcdefg2", "9365778295", "mango@gmail.com")]
        [TestCase(6499, "oreo", "abcdefg2", "9462753495", "oreo@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
                mockUserManager.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
                var result = await userManager.BuyerRegister(buyer);
                Assert.IsNotNull(result);
                Assert.AreEqual(true, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Register Buyer Unscuccessful
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="mobileNo"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [Test]
        [TestCase(7366, "apple", "abcdefg2", "9365778295", "apple@gmail.com")]
        //[TestCase(6499, "oreo", "abcdefg2", "9462753495", "oreo@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_UnSuccessfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
                mockUserManager.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(false);
                var result = await userManager.BuyerRegister(buyer);
                Assert.IsNotNull(result);
                Assert.AreEqual(false, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// buyerLogin
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandinik", "abcdefg@")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                var result = await userManager.BuyerLogin(userName, password);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login Unsuccessfull
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandinik", "abcdef")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                var result = await userManager.BuyerLogin(userName, password);
                Assert.IsNull(result,"Invalid");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}

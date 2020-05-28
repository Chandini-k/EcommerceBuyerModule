using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserService.Controllers;
using UserService.Manager;

namespace UserServiceTesting
{
    [TestFixture]
    public class UserControllerTesting
    { 

        private UserController userController;
       private Mock<IUserManager> mockUserManageer;
        private Mock<ILogger<UserController>> logger;
       private  Mock<IConfiguration> configuration;

        [SetUp]
        public void Setup()
        {
            configuration = new Mock<IConfiguration>();
            mockUserManageer = new Mock<IUserManager>();
            logger = new Mock<ILogger<UserController>>();
            userController = new UserController(logger.Object,mockUserManageer.Object,configuration.Object);
            
        }
        [Test]
        [TestCase(6499, "oreo", "abcdefg2", "9462753495", "oreo@gmail.com")]
        [Description("Register Buyer")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime dateTime = System.DateTime.Now;
                mockUserManageer.Setup(x => x.BuyerRegister(It.IsAny<BuyerRegister>())).ReturnsAsync(new bool());
                BuyerRegister buyerRegister = new BuyerRegister() { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = dateTime };
                var result = await userController.Buyer(buyerRegister) as OkObjectResult;
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandinik", "abcdefg2")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                mockUserManageer.Setup(x => x.BuyerLogin(userName, password));
                var result = await userController.BuyerLogin(userName, password) as OkObjectResult;
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chand", "abcdefg@")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                mockUserManageer.Setup(d => d.BuyerLogin(userName, password)).ReturnsAsync((Login)(null));
                var result = await userController.BuyerLogin(userName, password)as OkObjectResult;
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}

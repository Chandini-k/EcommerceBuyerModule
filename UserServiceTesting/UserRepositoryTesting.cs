using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UserServiceTesting
{
    [TestFixture]
    public class TestUserRepository
    {
        IUserRepository userRepository;
        DbContextOptionsBuilder<BuyerdataContext> _builder;
        [SetUp]
        public void SetUp()
        {
            _builder = new DbContextOptionsBuilder<BuyerdataContext>().EnableSensitiveDataLogging().UseInMemoryDatabase(Guid.NewGuid().ToString());
            BuyerdataContext buyerdataContext = new BuyerdataContext(_builder.Options);
            userRepository = new UserRepository(buyerdataContext);
            buyerdataContext.Buyer.Add(new Buyer { Buyerid = 2341, Username = "chandu", Password = "abcdefg2", Email = "chand@gmail.com", Mobileno = "9876543213", Datetime = DateTime.Now });
            buyerdataContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            userRepository = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase(4343, "chinari", "abcdefg2","9365756295","chinnari@gmail.com")]
        [TestCase(6466, "cutepie", "abcdefg2", "9462753495", "cutepie@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId=email,dateTime = datetime };
                var result=await userRepository.BuyerRegister(buyer);
                Assert.NotNull(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login success
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandu","abcdefg2")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName,string password)
        {
            try
            {
                var result = await userRepository.BuyerLogin(userName,password);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("chandin", "abcdefg@")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName,string password)
        {
            try
            {
                var result = await userRepository.BuyerLogin(userName, password);
                Assert.IsNull(result,"Invalid");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }

}
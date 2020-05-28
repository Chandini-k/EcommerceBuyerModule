using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _iuserRepository;
        readonly List<Buyer> buyers = new List<Buyer>();
        public UserManager(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }
        public async Task<bool> BuyerRegister(BuyerRegister buyer)
        {
            Buyer buyer1 = new Buyer();
            var result = buyers.Where(i => i.Email.ToString() == buyer1.Email.ToString()).Select(i => i).ToList();
            if (result.Count>1)
            {
                return false;
            }
            else
            {

                bool user = await _iuserRepository.BuyerRegister(buyer);
                return user;
            }
        }

        public async Task<Login> BuyerLogin(string username,string password)
        {
            Login login1 = await _iuserRepository.BuyerLogin(username,password);
            if (login1!=null)
            {
                return login1;
            }
            else
            {
                Console.WriteLine("Invalid");
                return null;
            }
        }

    }
}

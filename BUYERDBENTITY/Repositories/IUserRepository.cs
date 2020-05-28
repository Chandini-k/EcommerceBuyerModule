using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public interface IUserRepository
    {
        Task<bool> BuyerRegister(BuyerRegister buyer);
        Task<Login> BuyerLogin(string username, string password);

    }
}

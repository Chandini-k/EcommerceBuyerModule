using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public interface IBuyerRepository
    {
        Task<bool> EditBuyerProfile(BuyerData buyer);
        Task<BuyerData> GetBuyerProfile(int bid);
    }
}

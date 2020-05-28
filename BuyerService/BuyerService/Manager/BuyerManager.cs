using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerService.Manager
{
    public class BuyerManager : IBuyerManager
    {
        private readonly IBuyerRepository _ibuyerRepository;
        public BuyerManager(IBuyerRepository ibuyerRepository)
        {
            _ibuyerRepository = ibuyerRepository;
        }
        public async Task<bool> EditBuyerProfile(BuyerData buyer)
        {
            bool user = await _ibuyerRepository.EditBuyerProfile(buyer);
            if (user)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<BuyerData> GetBuyerProfile(int bid)
        {
            BuyerData buyer = await _ibuyerRepository.GetBuyerProfile(bid);
            if (buyer == null)
            {
                return null;
            }
            else
            {
                return buyer;
            }
        }
    }
}

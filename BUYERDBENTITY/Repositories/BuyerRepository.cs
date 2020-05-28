using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly BuyerdataContext _context;
        public BuyerRepository(BuyerdataContext context)
        {
            _context = context;
        }
        public async Task<bool> EditBuyerProfile(BuyerData buyer)
        {
            Buyer buyer1 = _context.Buyer.Find(buyer.buyerId);
            if (buyer1 != null)
            {
                buyer1.Username = buyer.userName;
                buyer1.Password = buyer.password;
                buyer1.Mobileno = buyer.mobileNo;
                buyer1.Email = buyer.emailId;
                _context.Buyer.Update(buyer1);
                var user = await _context.SaveChangesAsync();
                if (user > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public async Task<BuyerData> GetBuyerProfile(int bid)
        {
            Buyer buyer = await _context.Buyer.FindAsync(bid);
            if (buyer == null)
                return null;
            else
            {
                BuyerData buyer1 = new BuyerData();
                buyer1.buyerId = buyer.Buyerid;
                buyer1.userName = buyer.Username;
                buyer1.password = buyer.Password;
                buyer1.emailId = buyer.Email;
                buyer1.mobileNo = buyer.Mobileno;
                return buyer1;
            }

        }
    }
}

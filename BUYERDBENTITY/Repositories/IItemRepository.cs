using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public interface IItemRepository
    {
        Task<List<Product>> Search(string itemName);
        Task<bool> BuyItem(PurchaseHistory purchase);
        Task<List<PurchaseHistory>> Purchase(int buyerId);
        Task<bool> AddToCart(AddCart cart);
        Task<int> GetCount(int bid);
        Task<bool> CheckCartItem(int buyerid, int itemid);
        Task<List<AddCart>> GetCarts(int bid);
        Task<bool> DeleteCart(int cartId);
        Task<AddCart> GetCartItem(int cartid);
        Task<List<Product>> Items(int price, int price1);
        

    }
}

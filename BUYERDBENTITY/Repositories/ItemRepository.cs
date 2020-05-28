using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly BuyerdataContext _context;
        public ItemRepository(BuyerdataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddToCart(AddCart cart)
        {
            Cart cart1 = new Cart();
            if (cart != null)
            {
                cart1.Cartid = cart.cartId;
                cart1.Buyerid = cart.buyerId;
                cart1.Itemid = cart.itemId;
                cart1.Price = cart.price;
                cart1.Itemname = cart.itemName;
                cart1.Description = cart.description;
                cart1.Stockno = cart.stockno;
                cart1.Remarks = cart.remarks;
                cart1.Imagename = cart.imageName;
            }
            _context.Cart.Add(cart1);
            var buyercart = await _context.SaveChangesAsync();
            if (buyercart > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> BuyItem(PurchaseHistory purchase)
        {
            Purchasehistory purchasehistory = new Purchasehistory();
            if (purchase != null)
            {
                purchasehistory.Purchaseid = purchase.purchaseId;
                purchasehistory.Buyerid = purchase.buyerId;
                purchasehistory.Transactiontype = purchase.transactionType;
                purchasehistory.Itemid = purchase.itemId;
                purchasehistory.Itemname = purchase.itemName;
                purchasehistory.Noofitems = purchase.noOfItems;
                purchasehistory.Datetime = purchase.dateTime;
                purchasehistory.Remarks = purchase.remarks;
                purchasehistory.Transactionstatus = purchase.transactionStatus;
            }
            _context.Purchasehistory.Add(purchasehistory);
            var buyitem = await _context.SaveChangesAsync();
            if (buyitem > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CheckCartItem(int buyerid, int itemid)
        {
            Cart cart = await _context.Cart.SingleOrDefaultAsync(e => e.Buyerid == buyerid && e.Itemid == itemid);
            if (cart != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            Cart cart = await _context.Cart.FindAsync(cartId);
            if (cart != null)
            {
                _context.Cart.Remove(cart);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AddCart> GetCartItem(int cartid)
        {
            Cart cart = await _context.Cart.FindAsync(cartid);
            if (cart == null)
                return null;
            else
            {
                AddCart cart1 = new AddCart();
                cart1.cartId = cart.Cartid;
                cart1.buyerId = cart.Buyerid;
                cart1.itemId = cart.Itemid;
                cart1.price = cart.Price;
                cart1.itemName = cart.Itemname;
                cart1.description = cart.Description;
                cart1.stockno = cart.Stockno;
                cart1.remarks = cart.Remarks;
                cart1.imageName = cart.Imagename;
                return cart1;
            }
        }

        public async Task<List<AddCart>> GetCarts(int bid)
        {
            List<Cart> cart = await _context.Cart.Where(e => e.Buyerid == bid).ToListAsync();
            if (cart == null)
                return null;
            else
            {
                List<AddCart> cart1 = cart.Select(s => new AddCart
                {
                    cartId = s.Cartid,
                    buyerId = s.Buyerid,
                    itemId = s.Itemid,
                    price = s.Price,
                    itemName = s.Itemname,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    imageName = s.Imagename,
                }).ToList();
                return cart1;
            }
        }

        public async Task<int> GetCount(int bid)
        {
            var count = await _context.Cart.Where(e => e.Buyerid == bid).ToListAsync();
            if (count != null)
            {
                int count1 = count.Count();
                return count1;
            }
            else
            {
                return 0;
            }
        }
        public async Task<List<Product>> Items(int price, int price1)
        {
            List<Items> items = await _context.Items.Where(e => e.Price >= price && e.Price <= price1).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<Product> products = items.Select(s => new Product
                {
                    productId = s.Itemid,
                    productName = s.Itemname,
                    price = s.Price,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    imageName = s.Imagename,
                }).ToList();
                return products;
            }
        }

        public async Task<List<PurchaseHistory>> Purchase(int buyerId)
        {
            Buyer buyer = _context.Buyer.Find(buyerId);
            if (buyer == null)
            {
                return null;
            }
            else
            {
                List<Purchasehistory> purchasehistories = await _context.Purchasehistory.Where(e => e.Buyerid == buyer.Buyerid).ToListAsync();
                if (purchasehistories == null)
                {
                    return null;
                }
                else
                {
                    List<PurchaseHistory> purchaseHistories = purchasehistories.Select(s => new PurchaseHistory
                    {
                        purchaseId = s.Purchaseid,
                        buyerId = s.Buyerid,
                        transactionType = s.Transactiontype,
                        itemId = s.Itemid,
                        itemName=s.Itemname,
                        noOfItems = s.Noofitems,
                        dateTime = s.Datetime,
                        remarks = s.Remarks,
                        transactionStatus = s.Transactionstatus,
                    }).ToList();
                    return purchaseHistories;
                }
            }

        }

        public async Task<List<Product>> Search(string itemName)
        {
            List<Items> items = await _context.Items.Where(e => e.Itemname == itemName).ToListAsync();
            if (items == null)
            {
                return null;
            }
            else
            {
                List<Product> products = items.Select(s => new Product
                {
                    productId = s.Itemid,
                    productName = s.Itemname,
                    price = s.Price,
                    description = s.Description,
                    stockno = s.Stockno,
                    remarks = s.Remarks,
                    imageName = s.Imagename,
                }).ToList();
                return products;
            }
        }
    }
}

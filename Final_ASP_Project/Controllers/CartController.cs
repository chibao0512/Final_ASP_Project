using Final_ASP_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_ASP_Project.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("User/Cart/AddItem")]
        public async Task<IActionResult> AddItem(int bookId, int qty = 1, int redirect = 0)
        {
            var cartCount = await AddItemCart(bookId, qty);
            if (redirect == 0)
                return Ok(cartCount);
            return RedirectToAction("CartUser");
        }
        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
        public async Task<int> AddItemCart(int bookId, int qty)
        {
            string userId = GetUserId();
            try
            {
                if (string.IsNullOrEmpty(userId))throw new Exception("User must have login");
                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new ShoppingCart
                    {
                        UserId = userId
                    };
                    _db.ShoppingCarts.Add(cart);
                }
                _db.SaveChanges();
                var cartItem = _db.Carts.FirstOrDefault(a => a.ShoppingCartId == cart.Id && a.BookId == bookId);
                if (cartItem is not null)
                {
                    _db.SaveChanges();
                    cartItem.Quantity += qty;
                }
                else
                {
                    var book = _db.books.Find(bookId);
                    cartItem = new Cart
                    {
                        BookId = bookId,
                        ShoppingCartId = cart.Id,
                        Quantity = qty,
                        UnitPrice = book.Book_Price 
                    };
                    _db.Carts.Add(cartItem);
                }
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }
        // Remove quantity of product 
        [Route("User/Cart/RemoveItem")]
        public async Task<IActionResult> RemoveItem(int bookId)
        {
            var cartCount = await RemoveCartItem(bookId);
            return RedirectToAction("CartUser");
        }

        [Route("User/Cart/CartUser")]
        public async Task<IActionResult> CartUser()
        {
            var cart = await GetCartItem();
            return View(cart);
        }

        [Route("User/Cart/GetTotalItemInCart")]
        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await GetCartItemCount();
            return Ok(cartItem);
        }
        public async Task<int> GetCartItemCount(string userId = "")
        {
            if (!string.IsNullOrEmpty(userId))
            {
                userId = GetUserId();
            }
            var data = await (from cart in _db.ShoppingCarts join cartDetail in _db.Carts
            on cart.Id equals cartDetail.ShoppingCartId select new { cartDetail.Id }).ToListAsync();
            return data.Count;
        }
        [Route("User/Cart/Checkout")]               
        public async Task<IActionResult> Checkout()
        {
            var isCheckedOut = await DoCheckout();
            if (!isCheckedOut)
            {
                TempData["Quantity"] = "Insufficient quantity of store in stock";
                return Redirect("~/User/Cart/CartUser");
            }
            else
            {
                TempData["Success"] = "Order Success, thanks for order";
                return Redirect("~/User/Cart/CartUser");
            }


        }
        public async Task<int> RemoveCartItem(int bookId)
        {
            string userId = GetUserId();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");
                // get to cart detail
                var cartItem = _db.Carts.FirstOrDefault(a => a.ShoppingCartId == cart.Id && a.BookId == bookId);
                if (cartItem is null)
                    throw new Exception("cart don't have item");
                else if (cartItem.Quantity == 1)
                    _db.Remove(cartItem);
                else
                    cartItem.Quantity = cartItem.Quantity - 1;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            var cartItemCount = await GetCartItemCount(userId);
            return cartItemCount;
        }

        public async Task<ShoppingCart> GetCartItem()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid userid");
            var shoppingCart = await _db.ShoppingCarts.Include(a => a.Carts).ThenInclude(a => a.Book)
                                  .ThenInclude(a => a.genre).Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return shoppingCart;

        }
        public async Task<ShoppingCart> GetCart(string userId)
        {
            var cart = await _db.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

       
        public async Task<bool> DoCheckout()
        {
            try
            {
                // move data from cartDetail to order and order detail then we will remove cart detail
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged-in");
                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid cart");
                var cartDetail = _db.Carts.Where(a => a.ShoppingCartId == cart.Id).ToList();
                if (cartDetail.Count == 0)
                    throw new Exception("Cart is empty");
                var order = new Order
                {
                    UserId = userId,
                    CreateDate = DateTime.UtcNow,
                };
                _db.Orders.Add(order);
                _db.SaveChanges();
                foreach (var item in cartDetail)
                {

                    var orderDetail = new OrderDetail
                    {
                        BookId = item.BookId,
                        OrderId = order.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    _db.OrderDetails.Add(orderDetail);
                    var quantity = _db.books.FirstOrDefault(a => a.book_Id == item.BookId);
                    if (quantity.book_Quantity < item.Quantity)
                    {
                        return false;
                    }
                    else
                    {
                        quantity.book_Quantity = quantity.book_Quantity - item.Quantity;
                        _db.Update(quantity);
                        _db.SaveChanges();
                 }
                }
                _db.Carts.RemoveRange(cartDetail);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

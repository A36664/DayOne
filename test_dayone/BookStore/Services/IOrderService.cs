using BookStore.Models.Carts;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public interface IOrderService
    {
        Task<int> CreateOrder(CheckoutRequest request);
    }
}

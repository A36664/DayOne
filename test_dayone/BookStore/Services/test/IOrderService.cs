using BookStore.Models.Carts;
using System.Threading.Tasks;

namespace BookStore.Services.test
{
    public interface IOrderService
    {
        Task<int> CreateOrder(CheckoutRequest request);
    }
}

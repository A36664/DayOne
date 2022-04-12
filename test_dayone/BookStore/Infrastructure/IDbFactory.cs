using BookStore.Data.EF;
using System;

namespace BookStore.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BookStoreContext Init();
    }
}

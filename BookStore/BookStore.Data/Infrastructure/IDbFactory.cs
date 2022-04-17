using System;
using BookStore.Data.EF;

namespace BookStore.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BookStoreContext Init();
    }
}

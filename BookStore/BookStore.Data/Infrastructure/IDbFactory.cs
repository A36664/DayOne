using BookStore.Data.EF;
using System;

namespace BookStore.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BookStoreContext Init();
    }
}

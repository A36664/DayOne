using BookStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BookStoreContext _context;

        public DbFactory()
        {
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }

        public BookStoreContext Init()
        {
            return _context ?? (_context = new BookStoreContext());
        }

       
    }
}

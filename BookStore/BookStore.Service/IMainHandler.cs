using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public interface IMainHandler
    {

        object Handle(object sender, string type, string ev);
    }
}

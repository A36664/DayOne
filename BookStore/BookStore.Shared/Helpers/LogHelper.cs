using log4net;
using System.Runtime.CompilerServices;

namespace BookStore.Shared.Helpers
{
    public class LogHelper
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }
    }
}

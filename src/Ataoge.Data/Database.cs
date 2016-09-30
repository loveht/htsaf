using System.Data.Common;
using Ataoge.Logging;

namespace Ataoge.Data
{
    public abstract class Database
    {
        readonly string connectionString;
        readonly DbProviderFactory dbProviderFactory;

        static readonly ILog Log = LogManager.GetLogger(typeof(Database));

        
    }
}
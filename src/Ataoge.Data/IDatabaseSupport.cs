using System.Data.Common;

namespace Ataoge.Data
{
    public interface IDatabaseSupport
    {
        DbParameter ConvertDbParameter(DbParameter safParameter);
        
    }
}
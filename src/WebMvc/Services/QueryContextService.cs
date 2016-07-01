using Microsoft.AspNetCore.Http;

namespace Ataoge.Services
{
    public class QueryContextService : IQueryContextService
    {
        
        private readonly IHttpContextAccessor _accessor;

        public QueryContextService(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public string GetString(string name, string defaultValue = null)
        {
            if (_accessor.HttpContext.Request.Query.ContainsKey(name))
                return _accessor.HttpContext.Request.Query[name];
            return defaultValue;
        }

        public int GetInt32(string name, int defaultValue = 0)
        {
            if (_accessor.HttpContext.Request.Query.ContainsKey(name))
            {
                int returnValue;
                if (int.TryParse(_accessor.HttpContext.Request.Query[name], out returnValue))
                    return returnValue;
            }
            return defaultValue;
        }
    }
}
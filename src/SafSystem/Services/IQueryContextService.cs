namespace Ataoge.Services
{
    public interface IQueryContextService
    {
        string GetString(string name, string defaultValue = null);

        int GetInt32(string name, int defaultValue = 0);
    }
}